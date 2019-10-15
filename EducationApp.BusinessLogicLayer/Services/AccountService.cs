using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.BusinessLogicLayer.Models;
using System;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;
        public AccountService(UserManager<Users> userManager, SignInManager<Users> signInManager, IEmailService emailService, IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory,IActionContextAccessor actionContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }
        public ActionResult<IEnumerable<string>> GetAuth()
        {
            var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var email = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var PassHash = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Hash);
            if (_httpContextAccessor.HttpContext.Response.StatusCode == 401)
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = 200;
                var refresh = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Refresh");
                return new string[] { "Error 401" };
            }
            return new string[] { Id?.Value, email?.Value, PassHash?.Value };
        }
        public async Task<ActionResult<string>> PostAuth( IJwtPrivateKey jwtPrivateKey, IJwtRefresh jwtRefresh, LoginModel login)
        {
            // Validate email
            Users user = new Users();
            var UserX = await _userManager.FindByEmailAsync(login.Email);
            if (UserX == null)
            {
                return "Вы ввели не правильный email. Возможно вы еще не зарегистрировались. Бегите, станьте нашим 1000-м посетителем!";
            }
            var confirmpass = await _userManager.CheckPasswordAsync(UserX, login.Password);
            if (!confirmpass)
            {
                return "Вы ввели не правильный пароль.";
            }
            // Token.    
            var claims = new List<Claim>()
            {
            new Claim(ClaimTypes.NameIdentifier, UserX.Id.ToString()),
            new Claim(ClaimTypes.Email,UserX.Email),
            new Claim(ClaimTypes.Hash, UserX.PasswordHash),
            };
            // JWT.
            var token = new JwtSecurityToken(
                issuer: "MyJwt",
                audience: "TheBestClient",
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: new SigningCredentials(
                        jwtPrivateKey.GetKey(),
                        jwtPrivateKey.SigningAlgorithm)
            );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var claimsref = new List<Claim>()
            {
            new Claim("Refresh", UserX.Email)
            };
            // JWT.
            var refreshtoken = new JwtSecurityToken(
                issuer: "MyJwt",
                audience: "TheBestClient",
                claims: claimsref,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: new SigningCredentials(
                        jwtRefresh.GetKey(),
                        jwtRefresh.SigningAlgorithm)
            );
            string refreshToken = new JwtSecurityTokenHandler().WriteToken(refreshtoken);
            return "RefreshToken =      " + refreshToken + "    AccessToken  =     " + jwtToken;
        }
        public async Task<ActionResult<string>> Register(RegisterModel reg)
        {
            Users user = new Users { Email = reg.Email, UserName = reg.Email };
            var result = await _userManager.CreateAsync(user, reg.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var regurl = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).Action(
                    "Account",
                    "ResetPassword",
                    new { userId = user.Id, code = code },
                    protocol: _httpContextAccessor.HttpContext.Request.Scheme);
                string subject = "Подтверждение регистрации";
                string message = $"Подтвердите регистрацию, перейдя по ссылке: <a href='{regurl}'>НАЖМИ НА МЕНЯ</a>";
                await _emailService.SendEmail(reg.Email, subject, message);
                await _signInManager.SignInAsync(user, false);
                return reg.ToString();
            }
            return result.ToString();
        }
        public async Task<ActionResult<string>> ForgotPassword(EmailModel email)
        {
            var user = await _userManager.FindByNameAsync(email.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return "ForgotPasswordConfirmation";
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).Action(
                "ResetPassword",
                "Account",
            new { userEmail = user.Email, code = code }, 
            protocol: _httpContextAccessor.HttpContext.Request.Scheme);
            string subject = "Изменение пароля ";
            string message = $"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>Нажми на меня</a>";
            await _emailService.SendEmail(email.Email, subject, message);
            return email.ToString();
        }
        public async Task<ActionResult<string>> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return "Error, userId or code null";
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return "Error, not user";
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return user.ToString();
            }
            return "Error, not Succeeded";
        }
        public async Task<ActionResult<string>> ResetPassword(ResetPasswordModel reset, string code, string userEmail, string password)
        {
            if (code == null || userEmail == null)
            {
                return "Error";
            }
            var user = await _userManager.FindByNameAsync(userEmail);
            if (user == null)
            {
                return "ResetPasswordConfirmation";
            }
            await _userManager.CheckPasswordAsync(user, password);
            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                return user.ToString();
            }
            return "Error, not Succeeded";
        }
        public async Task<ActionResult<string>> LogOut(LoginModel log)
        {
            await _signInManager.SignOutAsync();
            log.Email = log.Password = null;
            return "LogOut";
        }
        public async Task<ActionResult<string>> RefreshToken( string tokenString, IJwtPrivateKey jwtPrivateKey, IJwtRefresh jwtRefresh)
        {
            var jwtEncodedString = tokenString.Substring(7);
            Users user = new Users();
            var dtoken = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            string decodingtoken = dtoken.Claims.First(c => c.Type == "Refresh").Value;
            var UserX = await _userManager.FindByEmailAsync(decodingtoken);
            if (UserX == null)
            {
                return "Тебя нету в бд";
            }
            // Token.    
            var claims = new List<Claim>()
            {
            new Claim(ClaimTypes.NameIdentifier, UserX.Id.ToString()),
            new Claim(ClaimTypes.Email,UserX.Email),
            new Claim(ClaimTypes.Hash, UserX.PasswordHash),
            };
            // JWT.
            var token = new JwtSecurityToken(
                issuer: "MyJwt",
                audience: "TheBestClient",
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: new SigningCredentials(
                        jwtPrivateKey.GetKey(),
                        jwtPrivateKey.SigningAlgorithm)
            );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var claimsref = new List<Claim>()
            {
            new Claim("Refresh", UserX.Email)
            };
            // JWT.
            var refreshtoken = new JwtSecurityToken(
                issuer: "MyJwt",
                audience: "TheBestClient",
                claims: claimsref,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: new SigningCredentials(
                        jwtRefresh.GetKey(),
                        jwtRefresh.SigningAlgorithm)
            );
            string refreshToken = new JwtSecurityTokenHandler().WriteToken(refreshtoken);
            return "RefreshToken =      " + refreshToken + "    AccessToken  =     " + jwtToken;
        }
    }
}

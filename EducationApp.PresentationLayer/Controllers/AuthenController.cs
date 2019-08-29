﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.DataAccessLayer.AppContext;
using System;
using System.Net.Mail;
using System.Net;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EducationApp.BusinessLogicLayer.Models.User;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class AuthenController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly ApplicationContext _applicationContext;
        private readonly IEmailService _emailService;
        public AuthenController(UserManager<Users> userManager, SignInManager<Users> signInManager, ApplicationContext applicationContext, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationContext = applicationContext;
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var EmailIdentifier = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            return new string[] { EmailIdentifier?.Value, "value1", "value2" };
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> PostAsync(AuthenticationModel authRequest, [FromServices] IJwtPrivateKey jwtPrivateKey,[FromHeader] string email)
        {
            // Проверяем данные пользователя из запроса.
            Users user = new Users();
            var Findd = await _userManager.FindByEmailAsync(email);
            if (Findd == null)
            {
                return Ok("Вы еще не зарегистрировались. Бегите, станьте нашим 1000-м посетителем!");
            }
            
            // Создаем утверждения для токена.
            var claims = new Claim[]
            {
            new Claim(ClaimTypes.Email, email)
            };
         //   var EmailIdentifier = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            // Генерируем JWT.
            var token = new JwtSecurityToken(
                issuer: "MyJwt",
                audience: "TheBestClient",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                        jwtPrivateKey.GetKey(),
                        jwtPrivateKey.SigningAlgorithm)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return Ok(_applicationContext);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> AddRegister([FromBody]RegisterModel reg, [FromHeader]string subject, [FromHeader]string message)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users { Email = reg.Email, UserName = reg.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, reg.Password);
                if (result.Succeeded)
                {
                    // генерация токена для пользователя
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var regurl = Url.Action(
                        "ConfirmEmail",
                        "Authen",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    subject = "Подтверждение регистрации";
                    message = $"Подтвердите регистрацию, перейдя по ссылке: <a href='{regurl}'>НАЖМИ НА МЕНЯ</a>";
                    await _emailService.SendEmail(reg.Email, subject, message);
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Values");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok(reg);
        }

        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return Ok("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Ok("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return Ok(user);
            else
                return Ok("Error");
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> Emailpassword([FromBody]EmailModel email)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(email.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // пользователь с данным email может отсутствовать в бд
                    // тем не менее мы выводим стандартное сообщение, чтобы скрыть 
                    // наличие или отсутствие пользователя в бд
                    return View("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action(
                    "ResetPassword",
                    "Authen", 
                new { userEmail = user.Email, code = code }, protocol: HttpContext.Request.Scheme);

                string subject = "Изменение пароля ";
                string message = $"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>Нажми на меня</a>";
                await _emailService.SendEmail(email.Email, subject, message);
            }
            return Ok(email);
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel reset, string code, string userEmail,[FromHeader]string password)
        {
            if (code == null || userEmail == null)
            {
                return Ok("Error");
            }
            var user = await _userManager.FindByNameAsync(userEmail);
            if (user == null)
            {
                return Ok("ResetPasswordConfirmation");
            }
            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                return Ok(reset);
            }
           /* foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }*/
            return Ok(reset);
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginModel log)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(log.Email, log.Password, log.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(log.ReturnUrl) && Url.IsLocalUrl(log.ReturnUrl))
                    {
                        return Redirect(log.ReturnUrl);
                    }
                    else
                    {
                        return Ok(log);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");

                }


            }
            return Ok(log);
        }
    }
}

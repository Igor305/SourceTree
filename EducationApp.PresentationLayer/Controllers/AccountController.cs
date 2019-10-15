using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Authentication
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get/GetAuth
        ///
        /// </remarks>
        [HttpGet("Auth")]
        [Authorize]
        public ActionResult<IEnumerable<string>> GetAuth()
        {
            return _accountService.GetAuth();
        }
        /// <summary>
        ///  Log In
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post/PostAuth
        ///
        /// </remarks>
        [HttpPost("Auth")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> PostAuth([FromServices] IJwtPrivateKey jwtPrivateKey, [FromServices] IJwtRefresh jwtRefresh, [FromBody] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.PostAuth( jwtPrivateKey,  jwtRefresh, login);
            }
            return "Error, not IsValid";        
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> AddRegister([FromBody]RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.Register(reg);
            }
            return "Error, not IsValid";
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> ForgotPassword([FromBody]EmailModel email)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.ForgotPassword(email);
            }
            return "Error, not IsValid";
        }

        [HttpPost("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> ConfirmEmail(string userId, string code)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.ConfirmEmail(userId, code);
            }
            return "Error, not IsValid";
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> ResetPassword(ResetPasswordModel reset, string code, string userEmail, [FromHeader]string password)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.ResetPassword(reset, code, userEmail, password);
            }
            return "Error, not IsValid";
        }

        [HttpPost("LogOut")]
        public async Task<ActionResult<string>> LogOut([FromBody]LoginModel log)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.LogOut(log);
            }
            return "Error, not IsValid";
        }

        [HttpGet("RefreshToken")]
        public async Task<ActionResult<string>> RefreshToken([FromHeader] string tokenString, [FromServices] IJwtPrivateKey jwtPrivateKey, [FromServices] IJwtRefresh jwtRefresh)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.RefreshToken(tokenString, jwtPrivateKey, jwtRefresh);
            }
            return "Error, not IsValid";
        }






        








    }
}

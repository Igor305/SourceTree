﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using EducationApp.BusinessLogicLayer.Models.Account;

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
        ///     "Email":"karakymba@gmail.com",
        ///     "Password":"karaganda"
        ///
        /// </remarks>
        [HttpPost("Auth")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> PostAuth([FromServices] IJwtPrivateKey jwtPrivateKey, [FromServices] IJwtRefresh jwtRefresh, [FromBody] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.PostAuth(jwtPrivateKey, jwtRefresh, login);
            }
            return "Error, not IsValid";
        }
        /// <summary>
        ///  Register
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post/Register
        ///
        ///     "Email":"karakymba@gmail.com",
        ///     "Password":"karaganda",
        ///     "PasswordConfirm":"karaganda"
        ///     
        /// </remarks>
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register([FromBody]RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.Register(reg);
            }
            return "Error, not IsValid";
        }
        /// <summary>
        ///  Forgot Password
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post/ForgotPassword
        ///
        ///     "Email":"karakymba@gmail.com"
        ///     
        /// </remarks>
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
        /// <summary>
        ///  Confirm Password
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post/ConfirmEmail
        /// 
        ///     "Email":"karakymba@gmail.com",
        ///     
        /// </remarks>
        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery]ConfirmEmail confirmEmail)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.ConfirmEmail(confirmEmail.userId, confirmEmail.code);
            }
            return "Error, not IsValid";
        }
        /// <summary>
        ///  Reset Password
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post/ResetPassword
        /// 
        ///     "Email":"karakymba@gmail.com",
        ///     "Password":"karaganda",
        ///     "PasswordConfirm":"karaganda",
        ///     "Code":"ioprewthjypoiwreyortpo"
        ///     
        /// </remarks>
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordModel reset)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.ResetPassword(reset);
            }
            return "Error, not IsValid";
        }
        /// <summary>
        ///  Log Out
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post/LogOut
        /// 
        ///     "Email":"karakymba@gmail.com",
        ///     "Password":"karaganda"
        ///     
        /// </remarks>
        [HttpPost("LogOut")]
        public async Task<ActionResult<string>> LogOut([FromBody]LoginModel log)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.LogOut(log);
            }
            return "Error, not IsValid";
        }
        /// <summary>
        ///  Refresh Token
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get/RefreshToken
        /// 
        ///     "token":"karakymba@gmail.com",
        ///     
        /// </remarks>
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<string>> RefreshToken([FromBody] RefreshTokenModel refreshTokenModel, [FromServices] IJwtPrivateKey jwtPrivateKey, [FromServices] IJwtRefresh jwtRefresh)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.RefreshToken(refreshTokenModel, jwtPrivateKey, jwtRefresh);
            }
            return "Error, not IsValid";
        }
        [HttpGet("GetAllRole")]
        public object GetAllRoleUsers()
        {
            var all = _accountService.GetAllRoleUsers();
            return all;
        }
        [HttpPost("CreateRole")]
        public async Task<ActionResult<string>> CreateRole([FromBody] CreateRoleModel createRoleModel)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.CreateRoleUsers(createRoleModel);
            }
            return "Error, not IsValid";
        }
        [HttpDelete("DeleteRole")]
        public async Task<ActionResult<string>> DeleteRole([FromBody] DeleteRoleModel deleteRoleModel)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.DeleteRoleUsers(deleteRoleModel);
            }
            return "Error, not IsValid";
        }
        [HttpPost]
        public async Task<ActionResult<string>> ChangeRoleUser([FromBody] ChangeRoleUserModel changeRoleUserModel)
        {
            return await _accountService.ChangeRoleUser(changeRoleUserModel);
        }
    }
}

using EducationApp.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        ActionResult<IEnumerable<string>> GetAuth();
        Task<ActionResult<string>> PostAuth([FromServices] IJwtPrivateKey jwtPrivateKey, [FromServices] IJwtRefresh jwtRefresh, [FromBody] LoginModel login);
        Task<ActionResult<string>> Register(RegisterModel reg);
        Task<ActionResult<string>> ForgotPassword([FromBody]EmailModel email);
        Task<ActionResult<string>> ConfirmEmail(string userId, string code);
        Task<ActionResult<string>> ResetPassword(ResetPasswordModel reset, string code, string userEmail, [FromHeader]string password);
        Task<ActionResult<string>> LogOut(LoginModel log);
        Task<ActionResult<string>> RefreshToken([FromHeader] string tokenString, [FromServices] IJwtPrivateKey jwtPrivateKey, [FromServices] IJwtRefresh jwtRefresh);

    }
}

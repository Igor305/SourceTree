using EducationApp.BusinessLogicLayer.Models;
using EducationApp.BusinessLogicLayer.Models.Account;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        ActionResult<IEnumerable<string>> GetAuth();
        Task<ActionResult<string>> PostAuth(IJwtPrivateKey jwtPrivateKey, IJwtRefresh jwtRefresh, LoginModel login);
        Task<ActionResult<string>> Register(RegisterModel reg);
        Task<ActionResult<string>> ForgotPassword(EmailModel email);
        Task<ActionResult<string>> ConfirmEmail(string userId, string code);
        Task<ActionResult<string>> ResetPassword(ResetPasswordModel reset);
        Task<ActionResult<string>> LogOut(LoginModel log);
        Task<ActionResult<string>> RefreshToken(RefreshTokenModel refreshTokenModel, IJwtPrivateKey jwtPrivateKey, IJwtRefresh jwtRefresh);
        ICollection<Role> GetAllRoleUsers();
        Task<ActionResult<string>> CreateRoleUsers(CreateRoleModel createRoleModel);
        Task<ActionResult<string>> DeleteRoleUsers(DeleteRoleModel deleteRoleModel);
        Task<ActionResult<string>> ChangeRoleUser(ChangeRoleUserModel changeRoleUserModel);
    }
}

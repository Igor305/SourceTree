using EducationApp.BusinessLogicLayer.Models.User;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Create(CreateModel createModel);
        Task<IdentityResult> Update(EditModel editModel);
        Task Delete(DeleteModel deleteModel);
        Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel);
    }
}

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
        Task<IdentityResult> CreateAsync(CreateModel createmodel);
        Task<IdentityResult> EditAsync(EditModel editmodel);
        Task<IdentityResult> Delete(Guid id);
        Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel);
    }
}

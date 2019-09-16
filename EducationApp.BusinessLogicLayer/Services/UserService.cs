using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Models.User;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IdentityResult> CreateAsync(CreateModel createmodel)
        {
            return await _userRepository.CreateAsync(createmodel.Email, createmodel.Password);
        }
        public async Task<IdentityResult> EditAsync(EditModel editmodel)
        {
            return await _userRepository.EditAsync(editmodel.Id, editmodel.Email, editmodel.FirstName, editmodel.LastName, editmodel.PhoneNumber);
        }
        public async Task<IdentityResult> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }
        public async Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            return await _userRepository.ChangePassword(changePasswordModel.Id, changePasswordModel.OldPassword, changePasswordModel.NewPassword);
        }
    }
}

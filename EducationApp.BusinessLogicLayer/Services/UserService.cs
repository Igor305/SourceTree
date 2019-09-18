using EducationApp.BusinessLogicLayer.Models.User;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IdentityResult> Create(CreateModel createModel)
        {
            return await userRepository.Create(createModel.Email, createModel.Password);
        }
        public async Task<IdentityResult> Update(EditModel editModel)
        {
            return await userRepository.Update(editModel.Id, editModel.Email, editModel.FirstName, editModel.LastName, editModel.PhoneNumber);
        }
        public async Task Delete(DeleteModel deleteModel)
        {
        await userRepository.Delete(deleteModel.id);
        }
        public async Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            return await userRepository.ChangePassword(changePasswordModel.Id, changePasswordModel.OldPassword, changePasswordModel.NewPassword);
        }
    }
}

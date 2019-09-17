 using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly UserManager<Users> _userManager;
        public UserRepository(ApplicationContext dbContext, UserManager<Users> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Create(string Email, string password)
        {
            Users user = new Users { Email =  Email, UserName = Email };
            user.CreateDateTime = DateTime.Now;
            user.UpdateDateTime = DateTime.Now;
            IdentityResult result = await _userManager.CreateAsync(user, password);
            return result;
        }
        public async Task<IdentityResult> Update(Guid Id, string Email, string FirstName, string LastName, string PhoneNumber)
        {
            Users user = await _userManager.FindByIdAsync(Convert.ToString(Id));
            user.UpdateDateTime = DateTime.Now;
            user.Email = Email;
            user.UserName = Email;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.PhoneNumber = PhoneNumber;
            IdentityResult result = await _userManager.UpdateAsync(user);
            return result;
        }
        public async Task Delete(Guid id)
        {
            Users user = await _userManager.FindByIdAsync(Convert.ToString(id));
            user.IsDeleted = true;
        }
        public async Task<IdentityResult> ChangePassword(Guid id, string oldPassword, string newPassword)
        {
            Users user = await _userManager.FindByIdAsync(Convert.ToString(id));
            if (user != null)
            {
               
            }
            IdentityResult result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;
        }
    }
}

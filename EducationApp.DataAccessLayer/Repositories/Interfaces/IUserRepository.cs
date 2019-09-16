using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository: IGenericRepository<Users>
    {
       Task<IdentityResult> CreateAsync(string Email, string password);

       Task<IdentityResult> EditAsync(Guid Id, string Email, string FirstName, string LastName, string PhoneNumber);
       Task<IdentityResult> Delete(Guid id);
       Task<IdentityResult> ChangePassword(Guid id, string oldPassword, string newPassword);


    }
}

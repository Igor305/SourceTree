 using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Users> GetAll()
        {
            var all = _applicationContext.Users.ToList();
            return all;
        }
    }
}

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
        List<Users> GetAllIsDeleted();
        List<Users> GetAll();
    }
}

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
        List<Users> GetAll();
        void Create(CreateModel createModel);
        void Update(EditModel editModel);
        void Delete(DeleteModel deleteModel);
    }
}

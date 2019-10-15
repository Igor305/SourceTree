using EducationApp.BusinessLogicLayer.Models.User;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        List<Users> GetAllIsDeleted();
        List<Users> GetAll();
        void Create(CreateModel createModel);
        void Update(EditModel editModel);
        void Delete(DeleteModel deleteModel);
        void FinalRemoval(DeleteModel deleteModel);
    }
}

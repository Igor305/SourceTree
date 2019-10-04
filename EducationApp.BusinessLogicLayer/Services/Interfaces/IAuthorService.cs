using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        IEnumerable<Author> GetName(GetNameAuthorModel getNameAuthorModel);
        void Create(CreateAuthorModel createAuthorModel);
        void Update(UpdateAuthorModel updateAuthorModel);
        void Delete(DeleteAuthorModel deleteAuthorModel); 
    }
}

using EducationApp.BusinessLogicLayer.Models.Authors;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        string Create(CreateAuthorModel createAuthorModel);
        void Update(UpdateAuthorModel updateAuthorModel);
        void Delete(DeleteAuthorModel deleteAuthorModel);
    }
}

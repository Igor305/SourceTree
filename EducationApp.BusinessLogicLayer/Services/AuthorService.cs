using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public object GetAll()
        {
            var all = _authorRepository.GetAll();
            return all;
        }
        public object GetName(GetNameAuthorModel getNameAuthorModel)
        {
            var name = _authorRepository.GetName(getNameAuthorModel.Name);
            return name;
        }
        public string Create(CreateAuthorModel createAuthorModel)
        {
            _authorRepository.CreateAuthor(createAuthorModel.Name);
             return $"{createAuthorModel.Name} был успешно добавлен";            
        }
        public  void Update(UpdateAuthorModel updateAuthorModel)
        {
            _authorRepository.UpdateAuthor(updateAuthorModel.Name);
        }
        public void Delete(DeleteAuthorModel deleteAuthorModel)
        {
            _authorRepository.DeleteAuthor(deleteAuthorModel.Id);
        }
    }
}

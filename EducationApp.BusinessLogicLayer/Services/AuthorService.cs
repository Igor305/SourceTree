using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public string Create(CreateAuthorModel createAuthorModel)
        {
            string columnname = "Name";
            bool df = authorRepository.VerrifyName(createAuthorModel.Name, columnname);
            if (df)
            {
                authorRepository.CreateAuthor(createAuthorModel.Name);
                return $"{createAuthorModel.Name} был успешно добавлен";
            }                
            return $"{createAuthorModel.Name} - такой автор уже есть в базе данных";
        }
        public  void Update(UpdateAuthorModel updateAuthorModel)
        {
            authorRepository.UpdateAuthor(updateAuthorModel.Name);
        }
        public void Delete(DeleteAuthorModel deleteAuthorModel)
        {
            authorRepository.DeleteAuthor(deleteAuthorModel.Id);
        }
    }
}

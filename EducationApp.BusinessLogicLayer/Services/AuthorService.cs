using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public void GetAll()
        {
            _authorRepository.GetAll();
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

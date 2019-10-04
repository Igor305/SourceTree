using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public List<Author> GetAll()
        {
            var all = _authorRepository.GetAll();
            return all;
        }
        public IEnumerable<Author> GetName(GetNameAuthorModel getNameAuthorModel)
        {
            var all = _authorRepository.GetAll();
            var findNameAuthor = all.Where(x => x.Name == getNameAuthorModel.Name);
            return findNameAuthor;
        }
        public void Create(CreateAuthorModel createAuthorModel)
        {
            Author author = new Author();
            author.Name = createAuthorModel.Name;
            author.CreateDateTime = DateTime.Now;
            author.UpdateDateTime = DateTime.Now;
            _authorRepository.Create(author);       
        }
        public void Update(UpdateAuthorModel updateAuthorModel)
        {         
            var all = _authorRepository.GetAll();
            var findauthor = all.Find(x => x.Id == updateAuthorModel.Id);
            findauthor.Name = updateAuthorModel.Name;
            findauthor.UpdateDateTime = DateTime.Now;
            _authorRepository.Update(findauthor);
        }
        public void Delete(DeleteAuthorModel deleteAuthorModel)
        {
            var all = _authorRepository.GetAll();
            var findauthor = all.Find(x => x.Id == deleteAuthorModel.Id);
            findauthor.IsDeleted = true;
            _authorRepository.Update(findauthor);
        }
    }
}

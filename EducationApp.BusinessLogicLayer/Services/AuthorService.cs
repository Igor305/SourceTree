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
        public List<Author> GetAllIsDeleted()
        {
            var allIsDeleted = _authorRepository.GetAllIsDeleted();
            return allIsDeleted;
        }
        public IEnumerable<Author> GetName(GetNameAuthorModel getNameAuthorModel)
        {
            var all = _authorRepository.GetAll();
            var findNameAuthor = all.Where(x => x.Name == getNameAuthorModel.Name);
            return findNameAuthor;
        }
        public string Create(CreateAuthorModel createAuthorModel)
        {
            Author author = new Author();
            if (createAuthorModel.Name == null)
            {
                string noNull = "Name not null";
                return noNull;
            }
            var all = _authorRepository.GetAll();
            var cloneauthor = all.FirstOrDefault(x => x.Name == createAuthorModel.Name);
            if (cloneauthor.Name != null)
            {
                string noNull = "There is such a name";
                return noNull;
            }
            author.Name = createAuthorModel.Name;
            if (createAuthorModel.DateBirth > createAuthorModel.DataDeath)
            {
                string dateNotValide = "Date vot valide";
                return dateNotValide;
            }
            if ((createAuthorModel.DateBirth> DateTime.Now)||(createAuthorModel.DataDeath > DateTime.Now))
            {
                string dateNotVanga = "The future has not come yet";
                return dateNotVanga;
            }
            author.DataBirth = createAuthorModel.DateBirth;
            author.DataDeath = createAuthorModel.DataDeath;
            author.CreateDateTime = DateTime.Now;
            author.UpdateDateTime = DateTime.Now;
            _authorRepository.Create(author);
            string status = "Добавлена новая запись";
            return status;
        }
        public string Update(UpdateAuthorModel updateAuthorModel)
        {         
            var all = _authorRepository.GetAll();
            var findauthor = all.Find(x => x.Id == updateAuthorModel.Id);
            if (updateAuthorModel.Name == null)
            {
                string noNull = "Name not null";
                return noNull;
            }
            findauthor.Name = updateAuthorModel.Name;
            if (updateAuthorModel.DateBirth > updateAuthorModel.DataDeath)
            {
                string dateNotValide = "Date vot valide";
                return dateNotValide;
            }
            if ((updateAuthorModel.DateBirth > DateTime.Now) || (updateAuthorModel.DataDeath > DateTime.Now))
            {
                string dateNotVanga = "The future has not come yet";
                return dateNotVanga;
            }
            findauthor.DataBirth = updateAuthorModel.DateBirth;
            findauthor.DataDeath = updateAuthorModel.DataDeath;
            findauthor.UpdateDateTime = DateTime.Now;
            _authorRepository.Update(findauthor);
            string status = "Добавлена новая запись";
            return status;
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

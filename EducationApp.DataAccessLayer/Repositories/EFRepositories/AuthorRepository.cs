using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository 
    {
        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public List<Author> GetAll()
        {
            var all = _applicationContext.Authors.ToList();
            return all;
        } 
        public object GetName(string Name)
        {
            var name = _applicationContext.Authors.Where(x => x.Name == Name);
            return name;
        }
        public void CreateAuthor(string Name)
        {                       
            Author author = new Author();
            author.Name = Name;
            author.CreateDateTime = DateTime.Now;
            author.UpdateDateTime = DateTime.Now;
            Create(author);
        }
        public void UpdateAuthor(string Name)
        {
            Author author = new Author();
            author.Name = Name;
            author.UpdateDateTime = DateTime.Now;
            Update(author);
        }
        public void DeleteAuthor(Guid Id)
        {
            Author author = new Author();
            var del = _applicationContext.Authors.Find(Id);
            author.IsDeleted = true;
            Update(del);
        }
    }
}

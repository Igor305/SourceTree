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
    }
}

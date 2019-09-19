using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationContext _applicationContext;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = applicationContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
        public bool VerrifyName(string name, string columnname)
        {
            bool test = _applicationContext.Authors.Any(x => x.Name == name);
            //bool fd = dbSet.Any(x =>x.columnname == Equals(name));
            return test;
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _applicationContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _applicationContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
        }
    }
}


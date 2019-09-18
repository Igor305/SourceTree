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
    public class GenericRepository<T> : IGenericRepository<T>where T: class
    {
        internal ApplicationContext applicationContext;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            dbSet = applicationContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public  T GetById(Guid id)
        {
            return dbSet.Find(id);
        }
        public string Find(string findName, string getType)
        {
           string first = dbSet.FirstOrDefault().ToString();
           return first;
        }
        public void Create(T entity)
        {
            dbSet.Add(entity);
            applicationContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            applicationContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
        }
    }
}


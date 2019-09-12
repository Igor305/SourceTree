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
        private readonly ApplicationContext _applicationContext;

        public GenericRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IQueryable<T> GetAll()
        {
            return _applicationContext.Set<T>().AsNoTracking();
        }
       /* public async Task<T> GetById(int id)
        {
            return _applicationContext.Find(id);
        }
        public async Task Create(T entity)
        {
            await _applicationContext.Set<T>().AddAsync(entity);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            _applicationContext.Set<T>().Update(entity);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _applicationContext.Set<T>().Remove(entity);
            await _applicationContext.SaveChangesAsync();
        }*/
    }
}


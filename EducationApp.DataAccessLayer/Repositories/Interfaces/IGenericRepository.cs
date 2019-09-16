using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> 
    {
        IQueryable<T> GetAll();

       /* Task<T> GetById(Guid id);*/

        Task Create(T entity);


        /*Task Update(Guid id, T entity);

        Task Delete(Guid id);*/
    }
}

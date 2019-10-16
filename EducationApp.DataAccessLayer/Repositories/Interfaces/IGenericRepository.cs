using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> 
    {

        T GetById(Guid id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> 
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);
        string Find(string name, string getType);

        void Create(T entity);

        void Update(T entity);

        void Delete(Guid id);
    }
}

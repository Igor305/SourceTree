using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        List<Author> GetAll();
        object GetName(string Name);
        void CreateAuthor(string Name);
        void UpdateAuthor(Guid Id,string Name);
        void DeleteAuthor(Guid Id);
    }
}
﻿using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        List<Author> GetAll();
        void CreateAuthor(string Name);
        void UpdateAuthor(string Name);
        void DeleteAuthor(Guid Id);
    }
}
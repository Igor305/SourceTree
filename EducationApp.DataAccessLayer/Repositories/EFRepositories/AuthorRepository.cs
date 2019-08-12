using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public AuthorRepository()
        {

        }

        public int Id()
        {
            return 1;
        }
        public string Name()
        {
            return "Мульберан";
        }
    }
}

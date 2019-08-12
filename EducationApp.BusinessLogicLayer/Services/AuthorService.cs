using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.EFRepositories;
using System;
using System.Collections.Generic;
using System.Text;
namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        AuthorRepository athor = new AuthorRepository();

        public int Id()
        {
            return athor.Id();
        }
        public string Name()
        {
            return athor.Name();
        }
    }
}

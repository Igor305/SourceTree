using EducationApp.BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
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

using System;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicLayer.Models.Autors
{
    public class AuthorsModel 
    {
        public string Name { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? DataDeath { get; set; }
    }
}

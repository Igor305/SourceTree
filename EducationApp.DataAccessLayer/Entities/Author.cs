using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Author : Basic
    {
        [Required]
        public string Name { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition { get; set; }
    }
}

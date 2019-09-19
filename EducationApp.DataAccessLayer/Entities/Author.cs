using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
namespace EducationApp.DataAccessLayer.Entities
{
    public class Author : Basic
    {
        public string Name { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition { get; set; }
    }
}

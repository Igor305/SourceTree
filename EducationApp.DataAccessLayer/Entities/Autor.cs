using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Autor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition { get; set; }
    }
}

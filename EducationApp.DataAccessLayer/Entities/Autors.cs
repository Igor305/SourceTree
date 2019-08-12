using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    class Autors
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AutorInPrintingEditions> AutorInPrintingEditions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AutorInPrintingEditions
    {
        [Key]
        public int AutorId { get; set; }
        public int PrintingEditionId { get; set; }
        public int Date { get; set; }
    }
}

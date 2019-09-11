using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AutorInPrintingEdition
    {
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }
        public Guid PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public int Date { get; set; }
    }
}

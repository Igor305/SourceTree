using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enum;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : Basic
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public TypeStatus Status { get; set; }
        public TypeCurrency Currency { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition { get; set; }       
    }

}

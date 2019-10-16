using EducationApp.BusinessLogicLayer.Models.Enums;
using EducationApp.DataAccessLayer.Entities.Enum;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class FiltrationPrintingEditionModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public TypeStatus Status { get; set; }
    }
}

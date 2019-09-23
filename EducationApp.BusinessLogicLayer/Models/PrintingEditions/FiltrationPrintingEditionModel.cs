using EducationApp.DataAccessLayer.Entities.Enum;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class FiltrationPrintingEditionModel
    {
        public string NameFilter { get; set; }
        public string ValueStringFilter { get; set; }
        public TypeStatus Status { get; set; }
    }
}

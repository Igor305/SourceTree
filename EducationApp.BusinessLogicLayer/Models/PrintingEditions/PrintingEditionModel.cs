using EducationApp.DataAccessLayer.Entities.Enum;
namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public TypeStatus Status { get; set; }
        public TypeCurrency Currency { get; set; }
    }
}


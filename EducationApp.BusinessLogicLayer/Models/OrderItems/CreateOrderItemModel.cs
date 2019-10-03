using EducationApp.DataAccessLayer.Entities.Enum;

namespace EducationApp.BusinessLogicLayer.Models.OrderItems
{
    public class CreateOrderItemModel
    {
        public int Amount { get; set; }
        public TypeCurrency Currency { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

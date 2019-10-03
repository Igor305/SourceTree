using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.OrderItems
{
    public class UpdateOrderItemModel
    {
        public Guid Id { get; set; }
        public int Amount { get; set; } 
        public TypeCurrency Currency { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

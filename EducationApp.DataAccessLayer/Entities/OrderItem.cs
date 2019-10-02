using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItem : Basic
    {
        public int Amount { get; set; }
        public TypeCurrency Currency { get; set; }
        public Guid PrintingEditionId { get; set; }
        public decimal Count { get; set; }
        public Guid OrderId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
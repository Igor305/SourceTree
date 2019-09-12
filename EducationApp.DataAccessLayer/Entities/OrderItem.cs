using EducationApp.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItem : Basic
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public Guid PrintingEditionId { get; set; }
        public string Count { get; set; }
        public Guid OrderId { get; set; }
        public string UnitPrice { get; set; }
    }
}
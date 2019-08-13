using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItems
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string PrintingEditionId { get; set; }
        public string Count { get; set; }
        public string OrderId { get; set; }
        public string UnitPrice { get; set; }
    }
}

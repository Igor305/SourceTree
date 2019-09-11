using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public Guid PaymentId { get; set; }
        public string Status { get; set; }
    }
}
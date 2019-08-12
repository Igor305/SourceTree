using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    class Orders
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public string PaymentId { get; set; }
        public string Status { get; set; }
    }
}

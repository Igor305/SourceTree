using EducationApp.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : Basic
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public Guid PaymentId { get; set; }
        public string Status { get; set; }
        public List<Users> Users { get; set; }
    }
}
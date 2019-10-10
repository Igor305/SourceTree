using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : Basic
    {

        public Guid UsersId { get; set; }
        public Users users { get; set; }
        public string Description { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
        public List<OrderItem> OrderItem { get; set; }
    }
}
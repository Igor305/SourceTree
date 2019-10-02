using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : Basic
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentId { get; set; }
        public TypeStatus Status { get; set; }
    }
}
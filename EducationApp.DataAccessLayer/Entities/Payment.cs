using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
    }
}
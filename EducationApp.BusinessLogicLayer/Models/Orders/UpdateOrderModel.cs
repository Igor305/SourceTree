using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Orders
{
    public class UpdateOrderModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

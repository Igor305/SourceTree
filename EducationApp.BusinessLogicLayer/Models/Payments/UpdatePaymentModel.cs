﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Payments
{
    public class UpdatePaymentModel
    {
        public Guid Id { get; set; }
        public string TransactionId { get; set; }

    }
}

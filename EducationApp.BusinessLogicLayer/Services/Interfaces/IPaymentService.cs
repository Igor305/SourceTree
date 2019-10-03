using EducationApp.BusinessLogicLayer.Models.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        void Transaction(PaymentModel paymentModel);
    }
}

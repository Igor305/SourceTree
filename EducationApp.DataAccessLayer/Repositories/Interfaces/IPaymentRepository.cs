using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    interface IPaymentRepository
    {
        List<Payment> GetAll();
        void CreatePayment(string TransactionId);
        void UpdatePayment(Guid Id, string TransactionId);
        void DeletePayment(Guid Id);
    }
}

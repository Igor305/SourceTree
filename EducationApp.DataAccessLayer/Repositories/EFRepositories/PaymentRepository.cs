using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
        public List<Payment> GetAll()
        {
            var all = _applicationContext.Payments.ToList();
            return all;
        }
        public void CreatePayment(string TransactionId)
        {
            Payment payment = new Payment();
            payment.TransactionId = TransactionId;
            payment.CreateDateTime = DateTime.Now;
            payment.UpdateDateTime = DateTime.Now;
            Create(payment);
        }
        public void UpdatePayment(Guid Id, string TransactionId)
        {
            var findPayment = _applicationContext.Payments.Find(Id);
            findPayment.TransactionId = TransactionId;
            findPayment.UpdateDateTime = DateTime.Now;
            Update(findPayment);
        }
        public void DeletePayment(Guid Id)
        {
            var findPayment = _applicationContext.Payments.Find(Id);
            findPayment.IsDeleted = true;
            Update(findPayment);
        }
    }
}

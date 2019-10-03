using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public void Transaction(PaymentModel paymentModel)
        {
            PaymentHelper paymentHelper = new PaymentHelper();
            string transactionId = paymentHelper.Charge(paymentModel.Email, paymentModel.Source,paymentModel.Description, paymentModel.Currency, paymentModel.Amount);
            _paymentRepository.CreatePayment(transactionId);
        }
    }
}

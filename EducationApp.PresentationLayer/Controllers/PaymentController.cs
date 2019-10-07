using EducationApp.BusinessLogicLayer.Models.Payments;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public object GetAll()
        {
            var all =_paymentService.GetAll();
            return all;
        }
        [HttpPost]
        public void Create([FromBody]PaymentModel paymentModel)
        {
             _paymentService.CreateTransaction(paymentModel);
        }
        [HttpPut]
        public void Update([FromBody]UpdatePaymentModel updatePaymentModel)
        {
            _paymentService.Update(updatePaymentModel);
        }
        [HttpDelete]
        public void Delete([FromBody]DeletePaymentModel deletePaymentModel)
        {
            _paymentService.Delete(deletePaymentModel);
        } 
        
    }
}

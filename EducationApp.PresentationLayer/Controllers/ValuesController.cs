using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Stripe;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Stripe;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ApplicationContext _applicationcontext;
        public ValuesController(ApplicationContext applicationContext)
        {
            this._applicationcontext = applicationContext;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Users> GetUsers()
        {
            return _applicationcontext.Users.ToList();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Charge([FromBody]StripeModel stripeModel)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

          /*  var options = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = "4242424242424242",
                    ExpYear = 2020,
                    ExpMonth = 10,
                    Cvc = "123"
                }
            };
            var service = new TokenService();
            Token stripeToken = service.Create(options);*/

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeModel.stripeEmail,
                Source = "tok_visa"
            });

            var charge = charges.Create(new ChargeCreateOptions
            {

                Amount = 50000,
                Description = "WoW",
                Currency = "usd",
                CustomerId = customer.Id
            });
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return Ok(BalanceTransactionId);
            }
            return Ok(customer.Id);
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

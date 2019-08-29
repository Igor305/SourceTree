using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class MailSenderController : Controller
    {
        private readonly IEmailService _emailService;
        public MailSenderController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromHeader]string email, [FromHeader]string subject, [FromHeader]string message)
        {
            await _emailService.SendEmail(email, subject, message);
            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.BusinessLogicLayer.Models.Autors;
using Microsoft.Extensions.Logging;
using EducationApp.DataAccessLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers.Base
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private IAuthorService _author;
        private readonly ILogger _logger;
        public TestController(IAuthorService author, ILogger<TestController> logger)
        {
            this._author = author;
            _logger = logger;
        }

        [HttpGet]
        public string Get(int id)
        {
            return "Ты куда зашёл?";
        }

        [HttpPost]
        public ActionResult Index([FromBody] Users user)
        {
            string email = user.Email;


            if (email != null) { return CreatedAtRoute(new { email = user.Email }, user); }
            return CreatedAtRoute(new { email = user.Email },user + "Всё плохо");
        }
        [HttpPut]
        public ActionResult Put([FromBody]Users user)
        {
            return CreatedAtRoute(new { email = user.Email }, user);
        }
    }
}

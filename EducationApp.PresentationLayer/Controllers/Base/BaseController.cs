using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.BusinessLogicLayer.Models.Autors;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers.Base
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IAuthorService _author;
        private readonly ILogger _logger;
        public BaseController(IAuthorService author, ILogger<BaseController> logger)
        {    
            this._author = author;
             _logger = logger;
        }

        [HttpGet]
        public string Get(string id, string name)
        {
           string Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation("Message displayed: {Message}", Message);
            return _author.Id() + " " + _author.Name();
        }
    }
}

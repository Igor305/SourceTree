using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.BusinessLogicLayer.Models.Autors;
using Microsoft.Extensions.Logging;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.AppContext;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers.Base
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class TestController : ControllerBase
    {
        private IAuthorService _author;
        private readonly ApplicationContext _applicationcontext;
        public TestController(IAuthorService author, ApplicationContext applicationcontext)
        {
            this._author = author;
            _applicationcontext = applicationcontext;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _applicationcontext.Users.ToList();
        }
    }
}

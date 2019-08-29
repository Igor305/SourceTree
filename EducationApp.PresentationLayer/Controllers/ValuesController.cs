using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;


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
        public string Post([FromBody]Users user)
        {
            if (_applicationcontext.Users == null)
            {
            _applicationcontext.Users.Add(new Users { FirstName = " ",LastName = " ", PasswordHash = " ", Email = "@mardan@" });
            _applicationcontext.SaveChanges();
                return "Я внес новые данные";
            }

            _applicationcontext.SaveChanges();
            return "Я сохранился";
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

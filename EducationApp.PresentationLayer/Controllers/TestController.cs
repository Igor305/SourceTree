using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
            private ApplicationContext db;
            public TestController(ApplicationContext context)
            {
                db = context;
            }
            [HttpPost]
            public async Task<IActionResult> Create(Autors autors)
            {
                db.Autors.Add(autors);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
    }
}

using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.EFRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        } 
        [HttpGet("{GetAll}")]
        public object GetAll()
        {
            if (ModelState.IsValid)
            {
                var all =_authorService.GetAll();
                return all;
            }
            return "Запись не валидна(";
        }
        [HttpGet("GetName")]
        public object GetName([FromBody]GetNameAuthorModel getNameAuthorModel)
        {
            if (ModelState.IsValid)
            {
                var all = _authorService.GetName(getNameAuthorModel);
                return all;
            }
            return "Запись не валидна(";
        }
        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public string Create([FromBody]CreateAuthorModel createAuthorModel)
        {
            if (ModelState.IsValid)
            {
                _authorService.Create(createAuthorModel);
                return "Добавлена новая запись";
            }
            return "Запись не валидна(";
        }
        [HttpPost("Update")]
        [Authorize(Roles = "admin")]
        public string Update([FromBody]UpdateAuthorModel updateAuthorModel)
        {
            if (ModelState.IsValid)
            {
                _authorService.Update(updateAuthorModel);
                return "Запись обновлена";
            }
            return "Запись не валидна(";
        }
        [HttpPost("Delete")]
        [Authorize(Roles = "admin")]
        public string Delete([FromBody]DeleteAuthorModel deleteAuthorModel)
        {
            if (ModelState.IsValid)
            {
                _authorService.Delete(deleteAuthorModel);
                return "Запись удалена";
            }
            return "Запись не валидна(";
        }
    }
}

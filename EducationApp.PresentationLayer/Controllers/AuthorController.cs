using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
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
        /// <summary>
        /// Get all Author
        /// </summary>
        [HttpGet("GetAll")]
        public object GetAll()
        {
            if (ModelState.IsValid)
            {
                var all =_authorService.GetAll();
                return all;
            }
            return "Запись не валидна(";
        }
        /// <summary>
        /// Get Name Author
        /// </summary>
        ///     /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetAll
        ///     {
        ///        "Name": "Пушкин"
        ///     }
        ///
        /// </remarks>
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
        /// <summary>
        /// Create new Author
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetName
        ///     {
        ///        "Name": "Пушкин"
        ///     }
        ///
        /// </remarks>
        [Produces("application/json")]
        [HttpPost("Create")]
        public string Create([FromBody]CreateAuthorModel createAuthorModel)
        {
            if (ModelState.IsValid)
            {
                _authorService.Create(createAuthorModel);
                return "Добавлена новая запись";
            }
            return "Запись не валидна(";
        }
        /// <summary>
        /// Udate Author for Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Update
        ///     {
        ///         "Id": "",
        ///         "Name": "Пушкин"
        ///     }
        ///
        /// </remarks>
        [HttpPut("Update")]
        public string Update([FromBody]UpdateAuthorModel updateAuthorModel)
        {
            if (ModelState.IsValid)
            {
                _authorService.Update(updateAuthorModel);
                return "Запись обновлена";
            }
            return "Запись не валидна(";
        }
        /// <summary>
        /// Delete  Author for Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Delete
        ///     {
        ///         "Id": ""
        ///     }
        ///
        /// </remarks>
        [HttpDelete("Delete")]
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

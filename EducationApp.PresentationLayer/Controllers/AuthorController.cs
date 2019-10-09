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
        /// Get all Author (IsDeleted = true)
        /// </summary>
        [HttpGet("GetAllIsDeleted")]
        public object GetAllIsDeleted()
        {
            if (ModelState.IsValid)
            {
                var allIsDeleted = _authorService.GetAllIsDeleted();
                return allIsDeleted;
            }
            return "Запись не валидна(";
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
        ///        "DateBirth":"1805-10-09T08:38:40.163Z",
        ///        "DatadDeath": "1855-10-09T08:38:40.163Z",
        ///     }
        ///
        /// </remarks>
        [Produces("application/json")]
        [HttpPost("Create")]
        public string Create([FromBody]CreateAuthorModel createAuthorModel)
        {
            if (ModelState.IsValid)
            {
                string result = _authorService.Create(createAuthorModel);
                return result;
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
        ///         "DateBirth":"1805-10-09T08:38:40.163Z",
        ///         "DatadDeath": "1855-10-09T08:38:40.163Z",
        ///     }
        ///
        /// </remarks>
        [Produces("application/json")]
        [HttpPut("Update")]
        public string Update([FromBody]UpdateAuthorModel updateAuthorModel)
        {
            if (ModelState.IsValid)
            {
                var result = _authorService.Update(updateAuthorModel);
                return result;
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
        [Produces("application/json")]
        [HttpDelete("Delete")]
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

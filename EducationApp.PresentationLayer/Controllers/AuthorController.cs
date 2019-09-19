using EducationApp.BusinessLogicLayer.Models.Authors;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.EFRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        [AcceptVerbs("Get","Post")]
        [HttpPost("{Create}")]
        public string Create([FromBody]CreateAuthorModel createAuthorModel)
        {
            if (ModelState.IsValid)
            {
                  return authorService.Create(createAuthorModel);
            }
            return $"{createAuthorModel.Name} - где значение?)";
        }
        [HttpPost("{Update}")]
        public string Update([FromBody]UpdateAuthorModel updateAuthorModel)
        {
            authorService.Update(updateAuthorModel);
            return $"{updateAuthorModel.Name} был успешно обновлён";
        }
        [HttpPost("{Delete}")]
        public string Delete([FromBody]DeleteAuthorModel deleteAuthorModel)
        {
            authorService.Delete(deleteAuthorModel);
            return $"{deleteAuthorModel.Id} был успешно удалён";
        }
    }
}

using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class PrintingEditionController : Controller
    {
        private readonly IPrintingEditionService _printingEditionService;
        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }
        [HttpPost("GetAll")]
        public void GetAll()
        {
            _printingEditionService.GetAll();
        }
        [HttpPost("Create")]
        public void Create()
        {
            CreatePrintingEditionModel createPrintingEditionModel = new CreatePrintingEditionModel();
            _printingEditionService.Create(createPrintingEditionModel);
        }
    }
}

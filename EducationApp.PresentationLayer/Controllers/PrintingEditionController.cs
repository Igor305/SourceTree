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
        [HttpGet("GetAll")]
        public object GetAll()
        {
            if (ModelState.IsValid)
            {
                var getAll = _printingEditionService.GetAll();
                return getAll;
            }
            return "Модель не валидная(";
        }
        [HttpPost("Buy")]
        public object Buy([FromBody]BuyPrintingEditionModel buyPrintingEditionModel)
        {
            if (ModelState.IsValid)
            {
                var buy = _printingEditionService.Buy(buyPrintingEditionModel);
                return buy;
            }
            return "Модель не валидная";
        }
        [HttpPost("Create")]
        public string Create([FromBody]CreatePrintingEditionModel createPrintingEditionModel)
        {
            if (ModelState.IsValid)
            {
                _printingEditionService.Create(createPrintingEditionModel);
                return "Добавлена новая запись";
            }
            return "Модель не валидная(";
        }
        [HttpPut("Update")]
        public string Update([FromBody]UpdatePrintingEditionModel updatePrintingEditionModel)
        {
            if (ModelState.IsValid)
            {
                _printingEditionService.Update(updatePrintingEditionModel);
                return "Запись обновлена";
            }
            return "Запись не валидна(";
        }
        [HttpDelete("Delete")]
        public string Delete([FromBody]DeletePrintingEditionModel deletePrintingEditionModel)
        {
            if (ModelState.IsValid)
            {
                _printingEditionService.Delete(deletePrintingEditionModel);
                return "Запись удалена";
            }
            return "Запись не валидна(";
        }
        [HttpPost("Sort")]
        public object Sort([FromBody]SortPrintingEditionModel sortPrintingEditionModel)
        {
            if (ModelState.IsValid)
            {
                var sort = _printingEditionService.Sort(sortPrintingEditionModel);
                return sort;
            }
            return "Модель не валидная(";
        }
        [HttpPost("Filter")]
        public object Filter([FromBody]FiltrationPrintingEditionModel filtrationPrintingEditionModel)
        {
            if (ModelState.IsValid)
            {
                var filter = _printingEditionService.Filter(filtrationPrintingEditionModel);
                return filter;
            }
            return "Модель не валидная(";
        }
    }
}

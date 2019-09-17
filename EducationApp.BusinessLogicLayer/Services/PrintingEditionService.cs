using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionsRepository _printingEditionsRepository;
        public PrintingEditionService(IPrintingEditionsRepository printingEditionsRepository)
        {
            _printingEditionsRepository = printingEditionsRepository;
        }
        public void CreatePrintingEdition(CreatePrintingEditionModel createPrintingEditionModel)
        {
             _printingEditionsRepository.CreatePrintingEdition(createPrintingEditionModel.Name, createPrintingEditionModel.Description, createPrintingEditionModel.Price, createPrintingEditionModel.Status, createPrintingEditionModel.Currency, createPrintingEditionModel.Type);
        }
        public void UpdatePrintingEdition(UpdatePrintingEditionModel updatePrintingEditionModel)
        {
            _printingEditionsRepository.UpdatePrintingEdition(updatePrintingEditionModel.Name, updatePrintingEditionModel.Description, updatePrintingEditionModel.Price, updatePrintingEditionModel.Status, updatePrintingEditionModel.Currency, updatePrintingEditionModel.Type);
        }
        public void DeletePrintingEdition(DeletePrintingEditionModel deletePrintingEditionModel)
        {
            _printingEditionsRepository.DeletePrintingEdition(deletePrintingEditionModel.Id);
        }
    }
}

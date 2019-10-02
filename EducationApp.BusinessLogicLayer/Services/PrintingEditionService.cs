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
        public object GetAll()
        {
            object all = _printingEditionsRepository.GetAll();
            return all;
        }
        public object Buy(BuyPrintingEditionModel buyPrintingEditionModel)
        {
            var buyPrintingEdition = _printingEditionsRepository.Buy(buyPrintingEditionModel.Id);
            if (buyPrintingEdition == null)
            {
                return "Нету печатного издания с таким Id";
            }
            return buyPrintingEditionModel;
        }
        public void Create(CreatePrintingEditionModel createPrintingEditionModel)
        {
             _printingEditionsRepository.CreatePrintingEdition(createPrintingEditionModel.Name, createPrintingEditionModel.Description, createPrintingEditionModel.Price, createPrintingEditionModel.Status, createPrintingEditionModel.Currency, createPrintingEditionModel.Type);
        }
        public void Update(UpdatePrintingEditionModel updatePrintingEditionModel)
        {
            _printingEditionsRepository.UpdatePrintingEdition(updatePrintingEditionModel.Id, updatePrintingEditionModel.Name, updatePrintingEditionModel.Description, updatePrintingEditionModel.Price, updatePrintingEditionModel.Status, updatePrintingEditionModel.Currency, updatePrintingEditionModel.Type);
        }
        public void Delete(DeletePrintingEditionModel deletePrintingEditionModel)
        {
            _printingEditionsRepository.DeletePrintingEdition(deletePrintingEditionModel.Id);
        }
        public object Sort(SortPrintingEditionModel sortPrintingEditionModel)
        {
            switch (sortPrintingEditionModel.NameSort)
            {
                case "Id":
                   var sortId = _printingEditionsRepository.SortId();
                    return sortId; 
                case "Name":
                    var sortName = _printingEditionsRepository.SortName();
                    return sortName;
                case "Price":
                    var sortPrice = _printingEditionsRepository.SortPrice();
                    return sortPrice;
                default:
                    return "Чёт не так)";
            }
        }
        public object Filter(FiltrationPrintingEditionModel filtrationPrintingEditionModel )
        {
            switch (filtrationPrintingEditionModel.NameFilter)
            {
                case "Name":
                    var filterName = _printingEditionsRepository.FilterName(filtrationPrintingEditionModel.ValueStringFilter);
                    return filterName;
                case "Price":
                    var filterPrice = _printingEditionsRepository.FilterPrice(filtrationPrintingEditionModel.ValueStringFilter);
                    return filterPrice;
                case "Status":
                    var filterStatus = _printingEditionsRepository.FilterStatus(filtrationPrintingEditionModel.Status);
                    return filterStatus;
                default:
                    return "Чет не так";
            }
        }
    }
}

using EducationApp.BusinessLogicLayer.Models.PrintingEditions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        object GetAll();
        void Create(CreatePrintingEditionModel createPrintingEditionModel);
        void Update(UpdatePrintingEditionModel updatePrintingEditionModel);
        void Delete(DeletePrintingEditionModel deletePrintingEditionModel);
        object Sort(SortPrintingEditionModel sortPrintingEditionModel);
        object Filter(FiltrationPrintingEditionModel filtrationPrintingEditionModel);
    }
}

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
        void CreatePrintingEdition(CreatePrintingEditionModel createPrintingEditionModel);
        void UpdatePrintingEdition(UpdatePrintingEditionModel updatePrintingEditionModel);
        void DeletePrintingEdition(DeletePrintingEditionModel deletePrintingEditionModel);
    }
}

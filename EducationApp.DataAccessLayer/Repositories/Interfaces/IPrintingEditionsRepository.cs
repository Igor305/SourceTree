using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionsRepository
    {
        List<PrintingEdition> GetAll();
        void CreatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type);
        void UpdatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type);
        void DeletePrintingEdition(Guid id);
    }
}

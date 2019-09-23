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
        object SortId();
        object SortName();
        object SortPrice();
        object FilterName(string Name);
        object FilterPrice(string Price);
        object FilterStatus(TypeStatus Status);
    }
}

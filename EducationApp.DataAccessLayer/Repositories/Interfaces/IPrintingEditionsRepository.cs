using EducationApp.DataAccessLayer.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionsRepository
    {
        void CreatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type);
        void UpdatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type);
        void DeletePrintingEdition(Guid id);
    }
}

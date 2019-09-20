using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class PrintingEditionsRepository : GenericRepository<PrintingEdition>, IPrintingEditionsRepository
    {
        public PrintingEditionsRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public List<PrintingEdition> GetAll()
        {
            PrintingEdition printingEdition = new PrintingEdition();
            var all = _applicationContext.PrintingEditions.ToList();
            return all;
        }
        public void CreatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type)
        {
            PrintingEdition printingEdition = new PrintingEdition();
            printingEdition.Name = Name;
            printingEdition.Description = Description;
            printingEdition.Price = Price;
            printingEdition.Status = Status;
            printingEdition.Currency = Currency;
            printingEdition.Type = Type;
            printingEdition.CreateDateTime = DateTime.Now;
            printingEdition.UpdateDateTime = DateTime.Now;
            Create(printingEdition);
            
        }
        public void UpdatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type)
        {
            PrintingEdition printingEdition = new PrintingEdition();
            printingEdition.Name = Name;
            printingEdition.Description = Description;
            printingEdition.Price = Price;
            printingEdition.Status = Status;
            printingEdition.Currency = Currency;
            printingEdition.Type = Type;
            printingEdition.UpdateDateTime = DateTime.Now;
            Update(printingEdition);
            
        }
        public void DeletePrintingEdition(Guid id)
        {
            var del = _applicationContext.PrintingEditions.Find(id);
            PrintingEdition printingEdition = new PrintingEdition();
            printingEdition.IsDeleted = true;
            Update(del);
        }
    }
}

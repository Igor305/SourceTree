using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class PrintingEditionsRepository : IPrintingEditionsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public PrintingEditionsRepository(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }
        public void CreatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type)
        {
            PrintingEdition printingEdition = new PrintingEdition
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Status = Status,
                Currency = Currency,
                Type = Type
            };
            printingEdition.CreateDateTime = DateTime.Now;
            printingEdition.UpdateDateTime = DateTime.Now;
            _applicationContext.PrintingEditions.Add(printingEdition);
            _applicationContext.SaveChanges();
            
        }
        public void UpdatePrintingEdition(string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type)
        {
            PrintingEdition printingEdition = new PrintingEdition
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Status = Status,
                Currency = Currency,
                Type = Type
            };
            _applicationContext.PrintingEditions.Update(printingEdition);
             printingEdition.UpdateDateTime = DateTime.Now;
            _applicationContext.SaveChanges();
            
        }
        public void DeletePrintingEdition(Guid id)
        {
            var del = _applicationContext.PrintingEditions.Find(id);
            PrintingEdition printingEdition = new PrintingEdition
            {
                IsDeleted = true
            };
            _applicationContext.PrintingEditions.Add(del);
            _applicationContext.SaveChanges();
        }
        public void FiltrationPrintingEdition(string Name, TypeStatus Status, string Price)
        {
        }
    }
}

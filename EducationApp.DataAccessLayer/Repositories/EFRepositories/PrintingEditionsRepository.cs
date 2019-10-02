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
            var all = _applicationContext.PrintingEditions.ToList();
            return all;
        }
        public object Buy(Guid Id)
        {
            var findBuyPrintingEdition = _applicationContext.PrintingEditions.Find(Id);
            return findBuyPrintingEdition;

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
        public void UpdatePrintingEdition(Guid Id, string Name, string Description, string Price, TypeStatus Status, TypeCurrency Currency, string Type)
        {
            var findPrintingEdition = _applicationContext.PrintingEditions.Find(Id);
            findPrintingEdition.Name = Name;
            findPrintingEdition.Description = Description;
            findPrintingEdition.Price = Price;
            findPrintingEdition.Status = Status;
            findPrintingEdition.Currency = Currency;
            findPrintingEdition.Type = Type;
            findPrintingEdition.UpdateDateTime = DateTime.Now;
            Update(findPrintingEdition);
            
        }
        public void DeletePrintingEdition(Guid id)
        {
            var del = _applicationContext.PrintingEditions.Find(id);
            del.IsDeleted = true;
            Update(del);
        }
        public object SortId()
        {
            var sortId =_applicationContext.PrintingEditions.OrderBy(s => s.Id);
            return sortId;
        }
        public object SortName()
        {
            var sortName = _applicationContext.PrintingEditions.OrderBy(s => s.Name);
            return sortName;
        }
        public object SortPrice()
        {
            var sortPrice = _applicationContext.PrintingEditions.OrderBy(s => s.Price);
            return sortPrice;
        }
        public object FilterName(string Name)
        {
            var filterName = _applicationContext.PrintingEditions.Where(x => x.Name == Name);
            return filterName;
        }
        public object FilterPrice(string Price)
        {
            var filterPrice = _applicationContext.PrintingEditions.Where(x => x.Price == Price);
            return filterPrice;
        }
        public object FilterStatus(TypeStatus Status)
        {
            var filterStatus = _applicationContext.PrintingEditions.Where(x => x.Status == Status);
            return filterStatus;
        }       
    }
}

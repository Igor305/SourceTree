using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class PrintingEditionsRepository : GenericRepository<PrintingEdition>, IPrintingEditionsRepository
    {
        public PrintingEditionsRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public List<PrintingEdition> GetAllIsDeleted()
        {
            var allIsDeleted = _applicationContext.PrintingEditions.IgnoreQueryFilters().ToList();
            return allIsDeleted;
        }
        public List<PrintingEdition> GetAll()
        {
            var all = _applicationContext.PrintingEditions.ToList();
            return all;
        }      
    }
}

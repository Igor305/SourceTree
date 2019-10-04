using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
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
    }
}

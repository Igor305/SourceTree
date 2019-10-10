using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionsRepository :IGenericRepository<PrintingEdition>
    {
        List<PrintingEdition> GetAllIsDeleted();
        List<PrintingEdition> GetAll();
    }
}

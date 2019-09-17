using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.PrintingEditions
{
    class FiltrationPrintingEditionModel
    {
        public string Name { get; set; }
        public TypeStatus Status { get; set; }
        public string Price { get; set; }
    }
}

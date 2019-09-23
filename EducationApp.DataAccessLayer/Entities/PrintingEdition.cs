using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enum;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : Basic
    {
        private readonly ILazyLoader _lazyLoader;
        public PrintingEdition() { }
        public PrintingEdition(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private List<AutorInPrintingEdition> _autorInPrintingEditions;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public TypeStatus Status { get; set; }
        public TypeCurrency Currency { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition
        {
            get => _lazyLoader.Load(this, ref _autorInPrintingEditions );
            set => _autorInPrintingEditions = value; }       
        }

}

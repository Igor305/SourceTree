using EducationApp.DataAccessLayer.Entities.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Author : Basic
    {
        private readonly ILazyLoader _lazyLoader;
        public Author() { }
        public Author(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private List<AutorInPrintingEdition> _autorInPrintingEditions;
        [Required]
        public string Name { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition
        {
            get => _lazyLoader.Load(this,ref _autorInPrintingEditions);
            set => _autorInPrintingEditions = value;
        }
    }
}

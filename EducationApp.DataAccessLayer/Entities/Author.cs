using EducationApp.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Author : Basic
    {

        [Required]
        public string Name { get; set; }
        public DateTime? DataBirth { get; set; }
        public DateTime? DataDeath { get; set; }

        private ICollection<AutorInPrintingEdition> _autorInPrintingEditions;
        public virtual ICollection<AutorInPrintingEdition> AutorInPrintingEdition
        {
            get => this._autorInPrintingEditions ?? (this._autorInPrintingEditions = new HashSet<AutorInPrintingEdition>());
            set => this._autorInPrintingEditions = value;
        }
    }
}

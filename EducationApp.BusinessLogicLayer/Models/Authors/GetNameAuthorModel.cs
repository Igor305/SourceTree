using EducationApp.BusinessLogicLayer.Models.Autors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Authors
{
    public class GetNameAuthorModel
    {
        [Required]
        public string Name { get; set; }
    }
}

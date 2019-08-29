using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities.Base
{
    public class Base
    {
        public int Id {get; set;}
        public string CreationDate { get; set; }
        public string Isremoved { get; set; }
    }
}

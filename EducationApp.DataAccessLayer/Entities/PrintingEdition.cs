﻿using EducationApp.DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : Basic
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string IsRemoved { get; set; }
        public enum Status { }
        public enum Currency { }
        public string Type { get; set; }
        public List<AutorInPrintingEdition> AutorInPrintingEdition { get; set; }
    }
    public enum Status
    {
    }
    public enum Currency
    {
    }
}

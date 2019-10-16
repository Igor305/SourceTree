using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.Account
{
    public class ConfirmEmail
    {
        public string userId { get; set; }
        public string code { get; set; }
    }
}

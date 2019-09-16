using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Models.User
{
    public class ChangePasswordModel
    {
        public Guid Id { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}

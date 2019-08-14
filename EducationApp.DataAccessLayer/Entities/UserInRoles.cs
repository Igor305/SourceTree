﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class UserInRoles
    {
        [Key]
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    public class UserInRoles 
    {
        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}

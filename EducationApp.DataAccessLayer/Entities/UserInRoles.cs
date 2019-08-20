using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class UserInRoles 
    {
        [Key]
        public int RoleId { get; set; }
        public Roles Role { get; set; }
        [Key]
        public int UserId { get; set; }
        public Users User { get; set; } 
    }
}

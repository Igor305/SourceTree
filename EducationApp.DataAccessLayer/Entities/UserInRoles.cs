using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class UserInRoles 
    {
        [Key]
        public Guid RoleId { get; set; }
        public Roles Role { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public Users User { get; set; } 
    }
}

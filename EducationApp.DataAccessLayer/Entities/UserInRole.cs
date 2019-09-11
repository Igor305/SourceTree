using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class UserInRole
    {
        [Key]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}
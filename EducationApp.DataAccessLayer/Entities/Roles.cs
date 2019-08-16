using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Roles: IdentityRole<Guid>
    {
        public Guid Id { get; set; }

        public List<UserInRoles> UserInRoly { get; set; }
        
    }
}

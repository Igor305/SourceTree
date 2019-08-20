using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Roles: IdentityRole<int>
    {

        public List<UserInRoles> UserInRoly { get; set; }
        
    }
}

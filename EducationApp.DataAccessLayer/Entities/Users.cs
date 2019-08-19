using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Users : IdentityUser<Guid> 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<UserInRoles> UserInRoly { get; set; }

    }
}

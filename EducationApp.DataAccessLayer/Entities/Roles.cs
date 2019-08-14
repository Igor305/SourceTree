using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserInRoles> UserInRoly { get; set; }
        
    }
}

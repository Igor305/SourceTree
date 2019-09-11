using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EducationApp.DataAccessLayer.Entities
{
    [Table("AspNetRefreshTokens")]
    public class RefreshToken
    {
        [Key]
        [StringLength(450)]
        public Guid Id { get; set; }

        public DateTime IssuedUtc { get; set; }

        public DateTime ExpiresUtc { get; set; }

        [Required]
        [StringLength(450)]
        public string Token { get; set; }

        public string Email { get; set; }

        public Users User { get; set; }
    }
}



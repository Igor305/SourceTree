using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Helpers
{
    public class CreateRefreshToken
    {
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

    }
}

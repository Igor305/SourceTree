using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IJwtPublicKey
    {
        SecurityKey GetKey();
    }
}

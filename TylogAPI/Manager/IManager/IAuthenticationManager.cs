using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.IManager
{
    public interface IAuthenticationManager
    {
        JwtSecurityToken GenerateToken(string secret, string validIssuer, string validAudience, int userId);
    }
}

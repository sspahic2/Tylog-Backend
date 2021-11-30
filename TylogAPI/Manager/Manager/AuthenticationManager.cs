using Manager.IManager;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class AuthenticationManager: IAuthenticationManager
    {
        public AuthenticationManager()
        {

        }

        public JwtSecurityToken GenerateToken(string secret, string validIssuer, string validAudience, int userId)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var claims = new List<Claim>();
            claims.Add(new Claim("id", userId.ToString()));
            return new JwtSecurityToken(issuer: validIssuer,
                                        audience: validAudience,
                                        expires: DateTime.Now.AddMinutes(30).AddHours(1.0),
                                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                                        claims: claims);
        }
    }
}

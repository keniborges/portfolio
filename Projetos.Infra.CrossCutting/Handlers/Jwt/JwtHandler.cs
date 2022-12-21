using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projetos.Infra.CrossCutting.Handlers.Jwt
{
    public class JwtHandler : IJwtHandler
    {
        public JwtHandlerReponse GetToken(JwtHandlerOptions options, string role = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = options.ExpireIn,
                NotBefore = DateTime.UtcNow.ToLocalTime(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.JwtPrivateKey)), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtHandlerReponse { Token = tokenHandler.WriteToken(token), ExpireIn = options.ExpireIn };
        }
    }
}

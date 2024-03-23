using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Models.Entities;
using UserService.Web.Auth.Interfaces;

namespace UserService.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("wqy8-2.cyEP{shJ1sp2r45TyuIU345]{mmadDG")),
            SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var securityToken = new JwtSecurityToken(
                issuer: "HiveHCM_Server",
                audience: "HiveHCM_Client",
                expires: DateTime.UtcNow.AddDays(30),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}

using UserService.Models.Entities;
using UserService.Web.Auth.Interfaces;

namespace UserService.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}

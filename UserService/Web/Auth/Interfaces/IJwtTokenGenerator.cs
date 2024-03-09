using UserService.Models.Entities;

namespace UserService.Web.Auth.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}

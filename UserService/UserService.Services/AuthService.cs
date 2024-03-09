using UserService.Models.Dtos;
using UserService.Persistance.Repositories.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;

        public AuthService(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<string> LoginAsync(
            UserLoginDto loginDto, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegistrateAsync(
            UserRegistrateDto registrateDto, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

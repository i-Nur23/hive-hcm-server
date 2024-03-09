using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Models.Dtos;

namespace UserService.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> RegistrateAsync(
            UserRegistrateDto registrateDto,
            CancellationToken cancellationToken = default);

        public Task<string> LoginAsync(
            UserLoginDto loginDto,
            CancellationToken cancellationToken = default);
    }
}

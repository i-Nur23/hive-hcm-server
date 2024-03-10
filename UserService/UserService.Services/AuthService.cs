using Azure.Core;
using Microsoft.EntityFrameworkCore;
using UserService.Models.Dtos;
using UserService.Models.Entities;
using UserService.Models.Enums;
using UserService.Models.Exceptions;
using UserService.Persistance.Repositories.Interfaces;
using UserService.Services.Auth.Interfaces;
using UserService.Services.Interfaces;
using UserService.Web.Auth.Interfaces;

namespace UserService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IHashService _hashService;
        
        public AuthService(
            IUsersRepository usersRepository, 
            IJwtTokenGenerator jwtTokenGenerator, 
            IDatabaseRepository databaseRepository,
            IHashService hashService)
        {
            _usersRepository = usersRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _databaseRepository = databaseRepository;
            _hashService = hashService;
        }

        public async Task<UserInfoDto> LoginAsync(
            UserLoginDto loginDto, 
            CancellationToken cancellationToken = default)
        {
            var user = await _usersRepository.GetByEmailAsync(loginDto.Email, cancellationToken);

            if (user is null || 
                !(await _hashService.VerifyAsync(
                    user.Password, 
                    loginDto.Password, 
                    cancellationToken)))
            {
                throw new WrongUserException();
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            var userInfo = new UserInfoDto()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Token = token
            };

            return userInfo;
        }

        public async Task<UserInfoDto> RegistrateAsync(
            UserRegistrateDto registrateDto, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _databaseRepository.StartTransactionAsync();

                var user = await _usersRepository.GetByEmailAsync(registrateDto.Email, cancellationToken);

                if (user is not null)
                {
                    throw new UserExistsException(registrateDto.Email);
                }

                var newUser = new User
                {
                    Name = registrateDto.Name,
                    Email = registrateDto.Email,
                    Password = await _hashService.CreateHashAsync(registrateDto.Password, cancellationToken),
                    Surname = registrateDto.Surname,
                    Role = Role.CEO,
                };


                await _usersRepository.AddAsync(newUser, cancellationToken);

                var token = _jwtTokenGenerator.GenerateToken(newUser);

                var userInfo = new UserInfoDto()
                {
                    Email = registrateDto.Email,
                    CompanyName = registrateDto.CompanyName,
                    Id = newUser.Id,
                    Name = registrateDto.Name,
                    Token = token
                };

                await _databaseRepository.CommitTransactionAsync();

                return userInfo;
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync();
                throw;
            }
        }
    }
}

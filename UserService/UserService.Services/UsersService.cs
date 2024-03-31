using Core.Events;
using Core.Exceptions;
using MassTransit;
using UserService.Models.Dtos;
using UserService.Models.Entities;
using UserService.Persistance.Repositories.Interfaces;
using UserService.Services.Auth.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IHashService _hashService;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UsersService(
            IUsersRepository usersRepository,
            IHashService hashService,
            IDatabaseRepository databaseRepository,
            IPublishEndpoint publishEndpoint)
        {
            _usersRepository = usersRepository;
            _hashService = hashService;
            _databaseRepository = databaseRepository;
            _publishEndpoint = publishEndpoint;
        }

        public UsersService(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task ChangePasswordAsync(
            Guid userId, 
            string oldPassword, 
            string newPassword, 
            CancellationToken cancellationToken = default)
        {
            User user = await _usersRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException("Пользователь не найден");
            }

            bool isRightPassword = await _hashService.VerifyAsync(
                user.Password,
                oldPassword,
                cancellationToken);

            if (!isRightPassword)
            {
                throw new BadRequestException("Вы ввели неверный текущий пароль");
            }

            if (oldPassword.Equals(newPassword))
            {
                return;
            }

            string newPasswordHash = await _hashService.CreateHashAsync(newPassword, cancellationToken);

            user.Password = newPasswordHash;

            await _usersRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task UpdateAsync(
            Guid userId,
            UpdateUserDto updateUserDto, 
            CancellationToken cancellationToken = default)
        {
            User user = await _usersRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException("Пользователь не найден");
            }

            user.Email = updateUserDto.Email;
            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;

            await _usersRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task<bool> TryCreateUserAsync(
            NewUserEvent newUser, 
            CancellationToken cancellationToken = default)
        {
            await _databaseRepository.StartTransactionAsync(cancellationToken);

            try
            {
                string password = GeneratePassword(12);

                string hashedPassword = await _hashService.CreateHashAsync(password, cancellationToken);

                await _publishEndpoint.Publish<EmailSendEvent>(new()
                {
                    Email = newUser.Email,
                    Subject = "Пароль для входа",
                    Body = $"Пароль: {password}" 
                });

                User user = new User()
                {
                    Email = newUser.Email,
                    Id = newUser.Id,
                    Surname = newUser.Surname,
                    Name = newUser.Name,
                    Password = hashedPassword,
                    RoleType = newUser.Role
                };

                await _usersRepository.AddAsync(user, cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken); 

                return true;
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
                return false;
            }
        }

        private string GeneratePassword(int length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
            char[] password = new char[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            return new string(password);
        }
    }
}

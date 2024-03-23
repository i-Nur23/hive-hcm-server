using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public UsersService(
            IUsersRepository usersRepository,
            IHashService hashService)
        {
            _usersRepository = usersRepository;
            _hashService = hashService;
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
    }
}

﻿using Core.Events;
using UserService.Models.Dtos;

namespace UserService.Services.Interfaces
{
    public interface IUsersService
    {
        public Task UpdateAsync(
            Guid userId,
            UpdateUserDto updateUserDto,
            CancellationToken cancellationToken = default);

        public Task ChangePasswordAsync(
            Guid userId,
            string oldPassword,
            string newPassword,
            CancellationToken cancellationToken = default);


        public Task<bool> TryCreateUserAsync(
            NewUserEvent newUserEvent,
            CancellationToken cancellationToken = default);

        public Task DeleteUserAsync(
            EmployeeFireEvent @event,
            CancellationToken cancellationToken = default);
    }
}

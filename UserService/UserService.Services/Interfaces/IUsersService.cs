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


    }
}

using Core.Events;
using Core.Exceptions;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserService.Models.Dtos;
using UserService.Persistance.Repositories.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IRequestClient<UserUpdatedEvent> _requestClient;

        public UserController(
            IUsersService usersService,
            IDatabaseRepository databaseRepository,
            IRequestClient<UserUpdatedEvent> requestClient)
        {
            _databaseRepository = databaseRepository;
            _usersService = usersService;
            _requestClient = requestClient;
        }

        private Guid UserId
        {
            get
            {
                return Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid value)
                    ? value
                    : throw new ForbiddenException();
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateUserDto updateUserDto)
        {
            CancellationToken cancellationToken = new CancellationToken();  

            try
            {
                await _databaseRepository.StartTransactionAsync(cancellationToken);

                await _usersService.UpdateAsync(UserId, updateUserDto, cancellationToken);

                var response = await _requestClient.GetResponse<RequestResult>(new UserUpdatedEvent()
                {
                    UserId = UserId,
                    Name = updateUserDto.Name,
                    Surname = updateUserDto.Surname,    
                    Patronymic = updateUserDto.Patronymic,
                    BirthDate = updateUserDto.BirthDate,
                    CountryCode = updateUserDto.CountryCode,
                    City = updateUserDto.City, 
                    Email = updateUserDto.Email,
                    PhoneNumber = updateUserDto.PhoneNumber,
                });

                if (response.Message.Ok)
                {
                    await _databaseRepository.CommitTransactionAsync(cancellationToken);

                    return Ok();
                } 
                else
                {
                    await _databaseRepository.RollbackTransactionAsync(cancellationToken);

                    var exception = new CustomResponseException(response.Message.Message);

                    exception.StatusCode = response.Message.StatusCode;

                    throw exception;
                }
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);

                throw;
            }
        }

        [HttpPost("password")]
        public async Task<IActionResult> ChangePasswordAsync(
            [FromBody] UserPasswordChangeDto passwordChangeDto)
        {
            await _usersService.ChangePasswordAsync(
                UserId,
                passwordChangeDto.OldPassword,
                passwordChangeDto.NewPassword);

            return Ok();
        }
    }
}

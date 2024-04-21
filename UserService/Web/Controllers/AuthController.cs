using Core.Events;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dtos;
using UserService.Services.Interfaces;

namespace UserService.Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AuthController(
            IAuthService authService,
            IPublishEndpoint publishEndpoint)
        {
            _authService = authService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registrate")]
        public async Task<IActionResult> Registrate([FromBody] UserRegistrateDto registrateDto)
        {
            Guid companyId = Guid.NewGuid();
            registrateDto.CompanyId = companyId;

            UserInfoDto userInfo = await _authService.RegistrateAsync(registrateDto);

            await _publishEndpoint.Publish(new CompanyCreatedEvent ()
            {
                Id = userInfo.Id,
                CompanyName = userInfo.CompanyName,
                Email = userInfo.Email,
                Name = userInfo.Name,
                Surname = userInfo.Surname,
                CompanyId = companyId,
            });

            return Ok(userInfo);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            UserInfoDto userInfo = await _authService.LoginAsync(loginDto);

            return Ok(userInfo);
        }
    }
}

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
        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registrate")]
        public async Task<IActionResult> Registrate([FromBody] UserRegistrateDto registrateDto)
        {
            UserInfoDto userInfo = await _authService.RegistrateAsync(registrateDto);

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

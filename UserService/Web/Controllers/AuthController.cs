using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dtos;

namespace UserService.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Registrate([FromBody] UserRegistrateDto registrateDto)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserRegistrateDto registrateDto)
        {


            return Ok();
        }

    }
}

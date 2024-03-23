using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Web.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok();
        }
    }
}

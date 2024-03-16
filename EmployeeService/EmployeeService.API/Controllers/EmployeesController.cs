using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {


            return Ok();
        }
    }
}

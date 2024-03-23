using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Authorize]
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            Employee employee =  await _employeesService.GetEmployeeByIdAsync(id);

            return Ok(employee);
        }
    }
}

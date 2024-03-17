using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee employee =  await _employeesService.GetEmployeeByIdAsync(id);

            return Ok(employee);
        }
    }
}

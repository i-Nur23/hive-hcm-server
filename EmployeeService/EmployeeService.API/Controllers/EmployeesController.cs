using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetEmployee()
        {
            Employee employee =  await _employeesService.GetEmployeeByIdAsync(UserId);

            return Ok(employee);
        }
    }
}

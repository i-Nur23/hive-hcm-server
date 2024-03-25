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
        private readonly IUnitsService _unitsService;

        public EmployeesController(
            IEmployeesService employeesService,
            IUnitsService unitsService)
        {
            _employeesService = employeesService;
            _unitsService = unitsService;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetEmployee()
        {
            Employee employee =  await _employeesService.GetEmployeeByIdAsync(UserId);

            return Ok(employee);
        }

        [HttpGet("units")]
        public async Task<IActionResult> GetUnitsAsync() 
        {
            IEnumerable<Unit> units = await _unitsService.GetLeadingUnitsAsync(UserId);

            return Ok(units);
        }

        [HttpGet("units/{unitId}")]
        public async Task<IActionResult> GetUnitInfoAsync(Guid unitId)
        {
            Unit unit = await _unitsService.GetUnitAsync(unitId);

            return Ok(unit);
        }
    }
}

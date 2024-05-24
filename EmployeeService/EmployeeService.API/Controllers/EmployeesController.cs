using Core.Enums;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Dtos;
using EmployeeService.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Authorize]
    [Route("api/employees")]
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
            IEnumerable<UnitInfoDto> units = await _unitsService.GetLeadingUnitsAsync(UserId);

            return Ok(units);
        }

        [HttpGet("units/{unitId}")]
        public async Task<IActionResult> GetUnitInfoAsync(Guid unitId)
        {
            Unit unit = await _unitsService.GetUnitAsync(unitId);

            return Ok(unit);
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddNewEmployeeAsync(
            [FromBody] NewUserDto newUserDto)
        {
            await _employeesService.AddEmployeeAsync(newUserDto);

            return Ok();
        }

        [HttpPost("set")]
        public async Task<IActionResult> SetEmployeeToUnitAsync(
            [FromBody] SetUserDto setUserDto)
        {
            await _employeesService.SetEmployeeAsync(setUserDto);

            return Ok();
        }

        [HttpGet("subs")]
        public async Task<IActionResult> GetSubEmployees()
        {
            List<Employee> employees = await _employeesService.GetSubEmployeesAsync(UserId);
            
            return Ok(employees);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCompanyEmployees(CancellationToken cancellationToken)
        {
            List<Employee> employees = await _employeesService.GetAllAsync(UserId, cancellationToken);

            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanyEmployeesWithoutUnit(
            [FromQuery] Guid unitId,
            CancellationToken cancellationToken)
        {
            List<Employee> employees = await _employeesService.GetAllNotIncludedInUnitAsync(
                UserId, 
                unitId , 
                cancellationToken);

            return Ok(employees);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveWorkerFromUnitAsync(
            [FromBody] RemoveWorkerDto removeWorkerDto,
            CancellationToken cancellationToken)
        {
            await _employeesService.RemoveFromUnitAsync(removeWorkerDto, cancellationToken);

            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListOfEmployees(
            CancellationToken cancellationToken)
        {
            IEnumerable<Employee> workingEmployees = await _employeesService.GetEmployeesByStatusAsync(
                EmployeeStatus.InCompany,
                CompanyId,
                UserId,
                cancellationToken);

            IEnumerable<Employee> firingEmployees = await _employeesService.GetEmployeesByStatusAsync(
                EmployeeStatus.FiringProcess,
                CompanyId,
                UserId,
                cancellationToken);

            return Ok(new
            {
                working = workingEmployees,
                firing = firingEmployees
            });
        }

        [HttpPost("fire")]
        public async Task<IActionResult> FireEmployeeAsync(
            Guid employeeId,
            CancellationToken cancellationToken)
        {
            await _employeesService.FireEmployeeAsync(employeeId, cancellationToken);

            return Ok();
        }

        [HttpPost("status")]
        public async Task<IActionResult> ChangeStatusAsync(
            Guid id,
            EmployeeStatus status, 
            CancellationToken cancellationToken)
        {
            await _employeesService.UpdateStatusAsync(
                id, 
                status, 
                cancellationToken);

            return Ok();
        }
    }
}

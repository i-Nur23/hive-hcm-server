using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Authorize]
    [Route("api/units")]
    public class UnitsController : BaseController
    {
        private readonly IUnitsService _unitsService;

        public UnitsController(
            IUnitsService unitsService)
        {
            _unitsService = unitsService;
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddNewUnit(
            [FromBody] NewUnitDto newUnitDto)
        {
            await _unitsService.AddUnitAsync(
                newUnitDto.ParentId, 
                newUnitDto.LeadId, 
                newUnitDto.Name);

            return Ok();
        }

    }
}

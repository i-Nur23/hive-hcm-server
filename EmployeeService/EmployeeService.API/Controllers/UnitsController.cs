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
                UserId,
                newUnitDto.ParentId, 
                newUnitDto.LeadId, 
                newUnitDto.Name);

            return Ok();
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetCompanyUnits(
            CancellationToken cancellationToken)
        {
            IEnumerable<UnitInfoDto> units = await _unitsService.GetCompanyUnitsAsync(
                CompanyId, 
                cancellationToken);

            return Ok(units);
        }

        [HttpDelete("{unitId}")]
        public async Task<IActionResult> DeleteUnitAsync(
            Guid unitId,
            CancellationToken cancellationToken)
        {
            await _unitsService.DeleteUnitAsync(unitId, cancellationToken);

            return Ok();
        }
    }
}

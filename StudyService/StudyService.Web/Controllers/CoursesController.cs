using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyService.Application.Interfaces;

namespace StudyService.Web.Controllers
{
    [Route("api/courses")]
    [Authorize]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(
            ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync(
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdminCoursesAsync(
            CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyService.Application.Interfaces;
using StudyService.Models.Dtos;

namespace StudyService.Web.Controllers
{
    [Route("api/courses")]
    [Authorize]
    [ApiController]
    public class CoursesController : BaseController
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
            var courses = await _coursesService.GetStudyingAsync(UserId);

            return Ok(courses);
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdminCoursesAsync(
            CancellationToken cancellationToken)
        {
            var courses = await _coursesService.GetAdminAsync(UserId);

            return Ok(courses);
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddNewCourseAsync(
            [FromBody] AddCourseDto courseDto)
        {
            await _coursesService.AddAsync(
                UserId,
                courseDto.Name,
                courseDto.StartDate,
                courseDto.EndDate,
                courseDto.StudentIds);

            return Ok();
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditCourseAsync(
            [FromBody] UpdateCourseDto courseDto)
        {
            await _coursesService.UpdateAsync(
                courseDto.CourseId,
                courseDto.Name,
                courseDto.StartDate,
                courseDto.EndDate,
                courseDto.StudentIds);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoodService.Application.RequestHandlers.Assessments;
using MoodService.Application.RequestHandlers.Assessments.Commands.CreateAssessment;
using MoodService.Application.RequestHandlers.Assessments.Queries.GetSubEmployeesAssessments;
using MoodService.Application.RequestHandlers.Assessments.Queries.GetUserCurrentAssessment;

namespace MoodService.Web.Controllers
{
    [Route("api/assessments")]
    [Authorize]
    public class AssessmentsController : BaseController
    {

        [HttpGet("statistics")]
        public async Task<IActionResult> GetLastWeekAssessmentsAsync(
            CancellationToken cancellationToken)
        {
            var query = new GetSubEmployeesAssessmentsQuery
            {
                LeadId = UserId
            };

            StatisticsVM statisticsVM = await Mediator.Send(query, cancellationToken);

            return Ok(statisticsVM);
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentAssessmentAsync(
            CancellationToken cancellationToken)
        {
            var query = new GetUserCurrentAssessmentQuery
            {
                UserId = UserId
            };

            AssessmentVM assessmentVM = await Mediator.Send(query, cancellationToken);

            return Ok(assessmentVM);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveAssessmentAsync(
            [FromBody] AssessmentVM assessment,
            CancellationToken cancellationToken)
        {
            var command = new CreateAssessmentCommand
            {
                Assessment = assessment,
                EmployeeId = UserId
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}

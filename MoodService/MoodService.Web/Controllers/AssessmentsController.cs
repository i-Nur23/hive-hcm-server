using Microsoft.AspNetCore.Mvc;
using MoodService.Application.RequestHandlers.Assessments;
using MoodService.Application.RequestHandlers.Assessments.Commands.CreateAssessment;

namespace MoodService.Web.Controllers
{
    public class AssessmentsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetLastWeekAssessmentsAsync(
            CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SaveAssessmentAsync(
            AssessmentVM assessment,
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentService.Application.Common.Dtos.Candidates;
using RecruitmentService.Application.Services.Candidates.Commands.CreateCandidate;
using RecruitmentService.Application.Services.Candidates.Commands.DeleteCandidate;

namespace RecruitmentService.Web.Controllers
{
    [Authorize]
    [Route("api/candidates")]
    public class CandidatesController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("new")]
        public async Task<IActionResult> CreateCandidateAsync(
            [FromBody] CreateCandidateDto candidateDto,
            CancellationToken cancellationToken)
        {
            var command = new CreateCandidateCommand
            {
                CreateCandidateDto = candidateDto
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteCandidateAsync(
            Guid candidateId,
            CancellationToken cancellationToken)
        {

            var command = new DeleteCandidateCommand
            {
                CandidateId = candidateId
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}

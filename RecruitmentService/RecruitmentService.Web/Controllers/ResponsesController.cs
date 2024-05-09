using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentService.Application.Common.Dtos.Responses;
using RecruitmentService.Application.RequestHandlers.Responses.Commands.AddResponse;
using RecruitmentService.Application.RequestHandlers.Responses.Commands.ChangeStatus;
using RecruitmentService.Application.RequestHandlers.Responses.Commands.HireCandidate;
using RecruitmentService.Domain.Enums;

namespace RecruitmentService.Web.Controllers
{
    [Route("api/responses")]
    public class ResponsesController : BaseController
    {
        [HttpPost("new")]
        public async Task<IActionResult> AddResponseAsync(
            [FromBody] ResponseCreateDto responseDto,
            CancellationToken cancellationToken = default)
        {
            var command = new AddResponseCommand
            {
                Response = responseDto,
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("set_status")]
        public async Task<IActionResult> ChangeStatusAsync(
            Guid responseId,
            ResponseStatus responseStatus,
            CancellationToken cancellationToken = default)
        {
            var command = new ChangeStatusCommand
            {
                ResponseId = responseId,
                NewStatus = responseStatus,
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("hire")]
        public async Task<IActionResult> HireCandidateAsync(
            Guid id,
            bool isHr,
            CancellationToken cancellationToken)
        {
            var command = new HireCandidateCommand
            {
                Id = id,
                IsHr = isHr,
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
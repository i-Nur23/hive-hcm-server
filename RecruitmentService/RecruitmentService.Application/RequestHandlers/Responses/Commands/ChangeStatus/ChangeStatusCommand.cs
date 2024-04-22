using MediatR;
using RecruitmentService.Domain.Enums;

namespace RecruitmentService.Application.RequestHandlers.Responses.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<Unit>
    {
        public Guid ResponseId { get; set; }

        public ResponseStatus NewStatus { get; set; }
    }
}

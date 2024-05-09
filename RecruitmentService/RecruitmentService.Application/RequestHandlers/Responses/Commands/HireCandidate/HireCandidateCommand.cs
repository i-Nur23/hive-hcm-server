using MediatR;

namespace RecruitmentService.Application.RequestHandlers.Responses.Commands.HireCandidate
{
    public class HireCandidateCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public bool IsHr { get; set; }
    }
}

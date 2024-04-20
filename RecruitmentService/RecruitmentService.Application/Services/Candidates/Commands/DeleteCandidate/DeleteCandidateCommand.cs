using MediatR;

namespace RecruitmentService.Application.RequestHandlers.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommand : IRequest<Unit>
    {
        public Guid CandidateId { get; set; }
    }
}

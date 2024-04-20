using MediatR;

namespace RecruitmentService.Application.Services.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommand : IRequest<Unit>
    {
        public Guid CandidateId { get; set; }
    }
}

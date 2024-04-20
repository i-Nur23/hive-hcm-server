using MediatR;
using RecruitmentService.Application.Common.Dtos.Candidates;

namespace RecruitmentService.Application.Services.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest<Unit>
    {
        public CreateCandidateDto CreateCandidateDto {  get; set; }
    }
}

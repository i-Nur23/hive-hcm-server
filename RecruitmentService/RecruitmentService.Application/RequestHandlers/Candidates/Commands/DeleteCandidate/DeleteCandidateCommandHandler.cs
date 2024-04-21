using AutoMapper;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.RequestHandlers.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommandHandler : 
        BaseRequestHandler,
        IRequestHandler<DeleteCandidateCommand, Unit>
    {
        public DeleteCandidateCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            DeleteCandidateCommand request, 
            CancellationToken cancellationToken)
        {
            Candidate? candidate = await _dbContext.Candidates
                .FirstOrDefaultAsync(c => c.Id.Equals(request.CandidateId));

            if (candidate is null)
            {
                throw new BadRequestException("Пользователь с таким Id не найден");
            }

            _dbContext.Candidates.Remove(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

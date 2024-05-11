using AutoMapper;
using MediatR;
using MoodService.Application.Common;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Application.RequestHandlers.Assessments.Commands.CreateAssessment
{
    public class CreateAssessmentCommandHandler :
        BaseRequestHandler,
        IRequestHandler<CreateAssessmentCommand, Unit>
    {
        public CreateAssessmentCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            CreateAssessmentCommand request, 
            CancellationToken cancellationToken)
        {
            Assessment assessment = _mapper.Map<Assessment>(request.Assessment);

            assessment.RatedAt = DateTime.UtcNow;

            await _dbContext.Assessments.AddAsync(assessment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

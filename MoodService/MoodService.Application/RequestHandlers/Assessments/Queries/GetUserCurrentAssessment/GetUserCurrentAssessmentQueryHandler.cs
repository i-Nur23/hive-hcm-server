using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoodService.Application.Common;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Application.RequestHandlers.Assessments.Queries.GetUserCurrentAssessment
{
    public class GetUserCurrentAssessmentQueryHandler :
        BaseRequestHandler,
        IRequestHandler<GetUserCurrentAssessmentQuery, AssessmentVM>
    {
        public GetUserCurrentAssessmentQueryHandler(
            IApplicationDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper) { }

        public async Task<AssessmentVM> Handle(
            GetUserCurrentAssessmentQuery request, 
            CancellationToken cancellationToken)
        {
            DateTime now = DateTime.UtcNow;

            DateTime startDate = now.AddDays(-(int)now.DayOfWeek - 6).Date;
            DateTime endDate = now.AddDays(-(int)now.DayOfWeek + 1).Date;

            Assessment? assessment = await _dbContext.Assessments.FirstOrDefaultAsync(
                a => 
                    a.EmployeeId.Equals(request.UserId) &&
                    a.RatedAt >= startDate && 
                    a.RatedAt < endDate);

            if (assessment is null)
            {
                return null;
            }

            return _mapper.Map<AssessmentVM>(assessment);
        }

    }
}

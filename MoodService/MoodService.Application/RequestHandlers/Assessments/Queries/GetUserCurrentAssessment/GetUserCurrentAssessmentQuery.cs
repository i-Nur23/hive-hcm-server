using MediatR;

namespace MoodService.Application.RequestHandlers.Assessments.Queries.GetUserCurrentAssessment
{
    public class GetUserCurrentAssessmentQuery : IRequest<AssessmentVM>
    {
        public Guid UserId { get; set; }
    }
}

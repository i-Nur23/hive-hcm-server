using MediatR;

namespace MoodService.Application.RequestHandlers.Assessments.Queries.GetSubEmployeesAssessments
{
    public class GetSubEmployeesAssessmentsQuery : IRequest<StatisticsVM>
    {
        public Guid LeadId { get; set; }
    }
}

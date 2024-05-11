using MediatR;

namespace MoodService.Application.RequestHandlers.Assessments.Commands.CreateAssessment
{
    public class CreateAssessmentCommand : IRequest<Unit>
    {
        public AssessmentVM Assessment {  get; set; }
        
        public Guid EmployeeId { get; set; }
    }
}

using MediatR;

namespace RecruitmentService.Application.Services.Divisions.Commands.DeleteDivision
{
    public class DeleteDivisionCommand : IRequest<Unit>
    {
        public Guid UnitId { get; set; }
    }
}

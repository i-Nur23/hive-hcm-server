using MediatR;

namespace RecruitmentService.Application.Services.Divisions.Commands.CreateDivision
{
    public class CreateDivisionCommand : IRequest<Unit>
    {
        public Guid UnitId { get; set; }

        public Guid LeadId { get; set; }

        public Guid CompanyId { get; set; }
    }
}

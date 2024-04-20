using MediatR;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Services.Divisions.Commands.CreateDivision
{
    public class CreateDivisionCommandHandler : IRequestHandler<CreateDivisionCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateDivisionCommandHandler(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(
            CreateDivisionCommand request, 
            CancellationToken cancellationToken)
        {
            await _dbContext.Divisions.AddAsync(new Division
            {
                CompanyId = request.CompanyId,
                Id = request.UnitId,
                LeadId = request.LeadId,
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

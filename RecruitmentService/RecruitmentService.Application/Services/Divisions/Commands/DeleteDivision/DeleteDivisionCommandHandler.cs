using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Services.Divisions.Commands.DeleteDivision
{
    public class DeleteDivisionCommandHandler : IRequestHandler<DeleteDivisionCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteDivisionCommandHandler(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(
            DeleteDivisionCommand request, 
            CancellationToken cancellationToken)
        {
            Division? division = await _dbContext.Divisions.FirstOrDefaultAsync(
                d => d.Id.Equals(request.UnitId),
                cancellationToken);

            if (division == null)
            {
                return Unit.Value;
            }

            _dbContext.Divisions.Remove(division);
            await _dbContext.SaveChangesAsync(cancellationToken);   

            return Unit.Value;
        }
    }
}

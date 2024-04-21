using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Services
{
    public class DivisionsService : IDivisionsService
    {
        private readonly IApplicationDbContext _dbContext;

        public DivisionsService(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(
            Guid divisionId, 
            Guid companyId, 
            Guid leadId, 
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Divisions.AddAsync(new Division
            {
                CompanyId = companyId,
                LeadId = leadId,
                Id = divisionId,
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(
            Guid divisionId, 
            CancellationToken cancellationToken = default)
        {
            _dbContext.Divisions.Remove(new Division
            {
                Id = divisionId,
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

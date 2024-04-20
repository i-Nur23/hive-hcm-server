using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        public DbSet<Candidate> Candidates { get; }

        public DbSet<Vacancy> Vacancies { get; }

        public DbSet<Job> Jobs { get; }

        public DbSet<Offer> Offers { get; }

        public DbSet<Requirement> Requirements { get; }

        public DbSet<Response> Responses { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public Task MigrateDatabaseAsync(CancellationToken cancellationToken = default);

        public DatabaseFacade Database { get; }
    }
}

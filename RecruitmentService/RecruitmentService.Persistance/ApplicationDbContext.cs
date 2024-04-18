using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;
using RecruitmentService.Persistance.Configurations;

namespace RecruitmentService.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Requirement> Requirements { get; set; }

        public DbSet<Response> Responses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public async Task MigrateDatabaseAsync(
            CancellationToken cancellationToken = default)
        {
            await Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VacancyConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
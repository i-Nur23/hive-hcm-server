using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentService.Persistance.Configurations
{
    internal class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder
                .HasMany(v => v.Candidates)
                .WithMany(c => c.Vacancies)
                .UsingEntity<Response>(
                    j => j
                        .HasOne(r => r.Candidate)
                        .WithMany(c => c.Responses)
                        .HasForeignKey(r => r.CandidateId),
                    j => j
                        .HasOne(r => r.Vacancy)
                        .WithMany(v => v.Responses)
                        .HasForeignKey(r => r.VacancyId)
                );
        }
    }
}

using Core.Events;
using MassTransit;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Web.Consumers
{
    public class UnitUpdatedConsumer : IConsumer<UnitUpdatedEvent>
    {
        private readonly IApplicationDbContext _dbContext;

        public UnitUpdatedConsumer(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<UnitUpdatedEvent> context)
        {
            Division? division = _dbContext.Divisions.FirstOrDefault(division => division.Id.Equals(context.Message.UnitId));

            if (division is null)
            {
                return;
            }

            division.LeadId = context.Message.LeadId;

            _dbContext.Divisions.Update(division);
            await _dbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}

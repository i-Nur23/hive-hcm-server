using Core.Events;
using MassTransit;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Web.Consumers
{
    public class CompanyCreatedConsumer : IConsumer<CompanyCreatedEvent>
    {
        private readonly IApplicationDbContext _dbContext;

        public CompanyCreatedConsumer(
            IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task Consume(ConsumeContext<CompanyCreatedEvent> context)
        {
            await _dbContext.Employees.AddAsync(new Employee
            {
                Id = context.Message.Id,
                Name = context.Message.Name,
                Surname = context.Message.Surname,
            }, context.CancellationToken);

            await _dbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}

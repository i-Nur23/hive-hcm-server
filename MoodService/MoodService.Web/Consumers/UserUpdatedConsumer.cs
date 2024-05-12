using Core.Events;
using MassTransit;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Web.Consumers
{
    public class UserUpdatedConsumer : IConsumer<UserUpdatedEvent>
    {
        private readonly IApplicationDbContext _dbContext;

        public UserUpdatedConsumer(
            IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {
            Employee? employee = _dbContext.Employees
                .FirstOrDefault(employee => employee.Id.Equals(context.Message.UserId));

            if (employee is null)
            {
                return;
            }

            employee.Name = context.Message.Name;
            employee.Surname = context.Message.Surname;

            _dbContext.Employees.Attach(employee);
            _dbContext.Employees.Update(employee);

            await _dbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}

using Core.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Web.Consumers
{
    public class EmployeeFireConsumer : IConsumer<EmployeeFireEvent>
    {
        private readonly IApplicationDbContext _dbContext;

        public EmployeeFireConsumer(
            IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task Consume(ConsumeContext<EmployeeFireEvent> context)
        {
            Employee? employee = await _dbContext.Employees
                .FirstOrDefaultAsync(
                    employee => employee.Id.Equals(context.Message.EmployeeId), 
                    context.CancellationToken);

            if (employee is null)
            {
                return;
            }

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}

using Core.Events;
using MassTransit;
using StudyService.Application.Interfaces;

namespace StudyService.Web.Consumer
{
    public class CompanyCreatedConsumer : IConsumer<CompanyCreatedEvent>
    {
        private readonly IEmployeesService _employeesService;

        public CompanyCreatedConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<CompanyCreatedEvent> context)
        {
            await _employeesService.AddAsync(
                context.Message.Id,
                context.Message.Name,
                context.Message.Surname,
                context.Message.Email,
                context.CancellationToken);
        }
    }
}

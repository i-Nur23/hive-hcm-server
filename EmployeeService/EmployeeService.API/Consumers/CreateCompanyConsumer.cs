using Core.Events;
using EmployeeService.Application.Interfaces;
using MassTransit;

namespace EmployeeService.API.Consumers
{
    public class CreateCompanyConsumer : IConsumer<CompanyCreatedEvent>
    {
        private readonly IEmployeesService _employeesService;

        public CreateCompanyConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<CompanyCreatedEvent> context)
        {
            await _employeesService.AddCeoAsync(context.Message);
        }
    }
}

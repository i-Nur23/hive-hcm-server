using Core.Dtos.MessageBroker;
using Core.Events;
using Core.Responses;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using MassTransit;

namespace EmployeeService.API.Consumers
{
    public class GetLeadingEmployeesConsumer : IConsumer<GetLeadingEmployeesEvent>
    {
        private readonly IEmployeesService _employeesService;

        public GetLeadingEmployeesConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<GetLeadingEmployeesEvent> context)
        {
            IEnumerable<Employee> employees = await _employeesService.GetSubEmployeesAsync(
                context.Message.LeadId,
                context.CancellationToken);

            await context.RespondAsync(new GetLeadingEmployeesResponse
            {
                Employees = employees.Select(emp => new EmployeeDto
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Surname = emp.Surname,
                })
            });
        }
    }
}

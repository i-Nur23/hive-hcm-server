using Core.Events;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Dtos;
using MassTransit;

namespace EmployeeService.API.Consumers
{
    public class CandidateHireConsumer : IConsumer<CandidateHireEvent>
    {
        private readonly IEmployeesService _employeesService;

        public CandidateHireConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<CandidateHireEvent> context)
        {
            CandidateHireEvent @event = context.Message;

            await _employeesService.AddEmployeeAsync(
                new NewUserDto
                {
                    UnitId = @event.UnitId,
                    BirthDate = @event.BirthDate,
                    Id = @event.Id,
                    Email = @event.Email,
                    Name = @event.Name,
                    Role = @event.Role,
                    Surname = @event.Surname,
                });
        }
    }
}

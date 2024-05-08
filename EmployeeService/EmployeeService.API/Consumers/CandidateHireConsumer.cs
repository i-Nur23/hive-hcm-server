using Core.Events;
using EmployeeService.Application.Interfaces;
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
            
        }
    }
}

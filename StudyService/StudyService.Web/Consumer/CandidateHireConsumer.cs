using Core.Events;
using MassTransit;
using StudyService.Application.Interfaces;

namespace StudyService.Web.Consumer
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
            await _employeesService.AddAsync(
                context.Message.Id,
                context.Message.Name,
                context.Message.Surname,
                context.Message.Email);
        }
    }
}

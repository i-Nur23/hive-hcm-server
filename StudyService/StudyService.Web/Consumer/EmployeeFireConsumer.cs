using Core.Events;
using MassTransit;
using StudyService.Application.Interfaces;

namespace StudyService.Web.Consumer
{
    public class EmployeeFireConsumer : IConsumer<EmployeeFireEvent>
    {
        private readonly IEmployeesService _employeesService;

        public EmployeeFireConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<EmployeeFireEvent> context)
        {
            await _employeesService.DeleteAsync(
                context.Message,
                context.CancellationToken);
        }
    }
}

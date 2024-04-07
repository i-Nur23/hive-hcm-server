using Core.Events;
using Core.Responses;
using MassTransit;
using StudyService.Application.Interfaces;

namespace StudyService.Web.Consumer
{
    public class NewUserConsumer : IConsumer<NewUserEvent>
    {
        private readonly IEmployeesService _employeesService;

        public NewUserConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<NewUserEvent> context)
        {
            bool isSuccess = true;

            try
            {
                await _employeesService.AddAsync(
                    context.Message.Id,
                    context.Message.Name,
                    context.Message.Surname,
                    context.Message.Email,
                    context.CancellationToken);
            }
            catch (Exception)
            {
                isSuccess = false;
            }

            await context.RespondAsync(new BaseResponse
            {
                IsSuccess = isSuccess
            });
        }
    }
}

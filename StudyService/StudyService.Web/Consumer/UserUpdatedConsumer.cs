using Core.Events;
using Core.Exceptions;
using Core.Responses;
using MassTransit;
using StudyService.Application.Interfaces;
using System.Net;

namespace StudyService.Web.Consumer
{
    public class UserUpdatedConsumer : IConsumer<UserUpdatedEvent>
    {
        private readonly IEmployeesService _employeesService;

        public UserUpdatedConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {
            try
            {
                await _employeesService.UpdateAsync(
                    context.Message.UserId,
                    context.Message.Name,
                    context.Message.Surname,
                    context.Message.Email,
                    context.CancellationToken);

                await context.RespondAsync<RequestResult>(new
                {
                    Ok = true
                });
            }
            catch (CustomResponseException exception)
            {
                await context.RespondAsync<RequestResult>(new
                {
                    Message = exception.Message,
                    Ok = false,
                    StatusCode = exception.StatusCode
                });
            }
            catch (Exception)
            {
                await context.RespondAsync<RequestResult>(new
                {
                    Message = "Ошибка сервера. Попробуйте позже.",
                    Ok = false,
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
        }
    }
}

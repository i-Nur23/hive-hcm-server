using Core.Events;
using Core.Responses;
using MassTransit;
using UserService.Services.Interfaces;

namespace UserService.Web.Consumers
{
    public class NewUserConsumer : IConsumer<NewUserEvent>
    {
        private readonly IUsersService _usersService;

        public NewUserConsumer(
            IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Consume(ConsumeContext<NewUserEvent> context)
        {
            await context.RespondAsync(
                new BaseResponse()
                {
                    IsSuccess = await _usersService.TryCreateUserAsync(context.Message),
                });
        }
    }
}

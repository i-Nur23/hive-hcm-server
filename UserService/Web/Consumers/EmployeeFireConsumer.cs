using Core.Events;
using MassTransit;
using UserService.Services.Interfaces;

namespace UserService.Web.Consumers
{
    public class EmployeeFireConsumer : IConsumer<EmployeeFireEvent>
    {
        private readonly IUsersService _usersService;

        public EmployeeFireConsumer(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Consume(ConsumeContext<EmployeeFireEvent> context)
        {
            await _usersService.DeleteUserAsync(
                context.Message,
                context.CancellationToken);
        }
    }
}

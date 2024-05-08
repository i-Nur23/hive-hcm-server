using Core.Events;
using MassTransit;
using UserService.Services.Interfaces;

namespace UserService.Web.Consumers
{
    public class CandidateHireConsumer : IConsumer<CandidateHireEvent>
    {
        private readonly IUsersService _usersService;

        public CandidateHireConsumer(
            IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Consume(ConsumeContext<CandidateHireEvent> context)
        {
            CandidateHireEvent @event = context.Message;

            await _usersService.TryCreateUserAsync(
                new NewUserEvent
                {
                    Id = @event.Id,
                    CompanyId = @event.CompanyId,
                    Email = @event.Email,
                    Name = @event.Name,
                    Role = @event.Role,
                    Surname = @event.Surname,
                });
        }
    }
}

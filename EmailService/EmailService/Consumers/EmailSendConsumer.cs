using Core.Events;
using EmailService.Clients.Interfaces;
using MassTransit;

namespace EmailService.Consumers
{
    public class EmailSendConsumer : IConsumer<EmailSendEvent>
    {
        private readonly IEmailClient _emailClient;

        public EmailSendConsumer(
            IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task Consume(ConsumeContext<EmailSendEvent> context)
        {
            await _emailClient.SendAsync(
                context.Message.Email,
                context.Message.Subject,
                context.Message.Body);
        }
    }
}

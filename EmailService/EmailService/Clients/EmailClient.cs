using EmailService.Clients.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace EmailService.Clients
{
    public class EmailClient : IEmailClient
    {
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _from;
        private readonly ILogger<EmailClient> _logger;

        public EmailClient(
            SmtpClient smtpClient, 
            MailAddress from,
            ILogger<EmailClient> logger)
        {
            _smtpClient = smtpClient;
            _logger = logger;
            _from = from;
        }

        public async Task SendAsync(
            string email, 
            string subject, 
            string body,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("New email:\n" +
                $"Email: {email}\n" +
                $"Body: {body}\n");

            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(_from, to);

            message.Subject = subject;
            
            message.Body = body;    

            message.IsBodyHtml = true;

            _smtpClient.Send(message);
        }
    }
}

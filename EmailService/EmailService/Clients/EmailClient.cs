using EmailService.Clients.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace EmailService.Clients
{
    public class EmailClient : IEmailClient
    {
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _from;
        private readonly IConfiguration _configuration;

        public EmailClient(
            SmtpClient smtpClient, 
            MailAddress from,
            IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
            _from = from;
        }

        public async Task SendAsync(
            string email, 
            string subject, 
            string body,
            CancellationToken cancellationToken = default)
        {
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(_from, to);

            message.Subject = subject;
            
            message.Body = body;    

            message.IsBodyHtml = true;

            _smtpClient.Send(message);
        }
    }
}

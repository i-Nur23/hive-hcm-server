namespace EmailService.Clients.Interfaces
{
    public interface IEmailClient
    {
        public Task SendAsync(
            string email,
            string subject,
            string body,
            CancellationToken cancellationToken = default);
    }
}

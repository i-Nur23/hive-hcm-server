namespace UserService.Services.Auth.Interfaces
{
    public interface IHashService
    {
        public Task<string> CreateHashAsync(
            string password, 
            CancellationToken cancellationToken = default);

        public Task<bool> VerifyAsync(
            string savedPassword,
            string password,
            CancellationToken cancellationToken = default);
    }
}

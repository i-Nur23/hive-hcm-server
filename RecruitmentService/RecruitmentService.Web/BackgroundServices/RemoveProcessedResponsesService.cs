using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;
using RecruitmentService.Domain.Enums;

namespace RecruitmentService.Web.BackgroundServices
{
    public class RemoveProcessedResponsesService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RemoveProcessedResponsesService> _logger;

        public RemoveProcessedResponsesService(
            IServiceProvider serviceProvider, 
            ILogger<RemoveProcessedResponsesService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IServiceScope scope = default;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    scope = _serviceProvider.CreateScope();
                    IApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

                    DateTime borderTime = DateTime.UtcNow.AddDays(-7);

                    IEnumerable<Response> removingResponse = dbContext.Responses
                        .Where(response => response.UpdatedAt < borderTime && 
                            (response.Status.Equals(ResponseStatus.Accepted) ||
                            response.Status.Equals(ResponseStatus.Refuse)))
                        .AsEnumerable();

                    dbContext.Responses.RemoveRange(removingResponse);
                    await dbContext.SaveChangesAsync(stoppingToken);    
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                finally 
                { 
                    scope.Dispose();
                    await Task.Delay(TimeSpan.FromDays(1));
                }
            }
        }
    }
}

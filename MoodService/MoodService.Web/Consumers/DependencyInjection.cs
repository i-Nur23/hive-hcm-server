using MassTransit;

namespace MoodService.Web.Consumers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMassTransitExtensions(
            this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}

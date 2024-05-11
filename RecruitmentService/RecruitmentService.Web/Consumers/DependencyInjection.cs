using MassTransit;

namespace RecruitmentService.Web.Consumers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMassTransitExtensions(
            this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<UnitCreatedConsumer>();
                x.AddConsumer<UnitDeletedConsumer>();
                x.AddConsumer<UnitUpdatedConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("create-unit-recruit", e =>
                    {
                        e.ConfigureConsumer<UnitCreatedConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("delete-unit-recruit", e =>
                    {
                        e.ConfigureConsumer<UnitDeletedConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("update-unit-recruit", e =>
                    {
                        e.ConfigureConsumer<UnitUpdatedConsumer>(context);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}

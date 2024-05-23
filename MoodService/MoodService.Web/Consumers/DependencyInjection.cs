using Core.Events;
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
                x.AddRequestClient<GetLeadingEmployeesEvent>();

                x.AddConsumer<CompanyCreatedConsumer>();
                x.AddConsumer<EmployeeFireConsumer>();
                x.AddConsumer<NewUserConsumer>();
                x.AddConsumer<UserUpdatedConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("company-created-mood", e =>
                    {
                        e.ConfigureConsumer<CompanyCreatedConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("employee-fire-mood", e =>
                    {
                        e.ConfigureConsumer<EmployeeFireConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("new-user-mood", e =>
                    {
                        e.ConfigureConsumer<NewUserConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("user-updated-mood", e =>
                    {
                        e.ConfigureConsumer<UserUpdatedConsumer>(context);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}

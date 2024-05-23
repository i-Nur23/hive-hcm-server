using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ScrapersService.Countries.Clients;
using ScrapersService.Countries.Clients.Interfaces;

namespace ScrapersService.Countries
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCountriesScraper(
            this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddScoped<ICountriesClient, CountriesClient>();

            services.AddHostedService<CountriesScraper>();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}

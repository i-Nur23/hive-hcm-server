using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScrapersService.Countries;

namespace ScrapersService.Main;

class Program
{
    public static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.RegisterCountriesScraper();

        IHost app = builder.Build();

        await app.RunAsync();

    }
}

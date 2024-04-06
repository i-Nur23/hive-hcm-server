using EmailService.Clients;
using EmailService.Clients.Interfaces;
using EmailService.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace EmailService;

class Program
{
    public static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = new HostApplicationBuilder();

        builder.Logging.AddConsole();

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<EmailSendConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.UseMessageRetry(r => r.Immediate(5));

                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        builder.Services.AddSingleton<IConfiguration>(_ =>
        {
            return new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .AddUserSecrets<Program>()
                    .Build();
        });

        builder.Services.AddSingleton<SmtpClient>(provider =>
        {
            IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

            IConfigurationSection configurationSection = configuration.GetSection("EmailOptions");

            return new SmtpClient(configurationSection["Host"], Int32.Parse(configurationSection["Port"]))
            {
                Credentials = new NetworkCredential(
                    configurationSection["Email"],
                    configurationSection["Password"]),
                EnableSsl = Convert.ToBoolean(configurationSection["EnableSsl"])
            };
        });

        builder.Services.AddSingleton<MailAddress>(provider =>
        {
            IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

            IConfigurationSection configurationSection = configuration.GetSection("EmailOptions");

            return new MailAddress(configurationSection["Email"], "HiveHCM");
        });

        builder.Services.AddScoped<IEmailClient, EmailClient>();

        IHost app = builder.Build();

        await app.RunAsync();
    }
}

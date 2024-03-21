using Core.Events;
using EmployeeService.API.Background;
using EmployeeService.API.Consumers;
using EmployeeService.Application;
using EmployeeService.Persistence;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDatabase(builder.Configuration);
services.AddHostedService<DatabaseMigrateService>();
services.AddServices();

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddMassTransit(x =>
{
    x.AddConsumer<CreateCompanyConsumer>();
    x.AddConsumer<CountriesScrapedConsumer>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

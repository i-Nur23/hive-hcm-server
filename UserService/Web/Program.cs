using Microsoft.OpenApi.Models;
using UserService.Auth;
using UserService.Persistance;
using UserService.Web.Extensions;
using Core.Middlewares;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using Core.Events;
using UserService.Web.Consumers;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddDatabase(builder.Configuration);
services.AddAuth(builder.Configuration);

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
services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
    });
});

services.AddRepositories();
services.AddServices();

services.AddMassTransit(x =>
{
    x.AddRequestClient<UserUpdatedEvent>();
    
    x.AddConsumer<NewUserConsumer>();
    x.AddConsumer<EmployeeFireConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("new-user-account", e =>
        {
            e.ConfigureConsumer<NewUserConsumer>(context);
        });

        cfg.ReceiveEndpoint("fire-employee-account", e =>
        {
            e.ConfigureConsumer<EmployeeFireConsumer>(context);
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

app.UseAuthentication();
app.UseAuthorization();

app.UseCustomMiddlewares();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
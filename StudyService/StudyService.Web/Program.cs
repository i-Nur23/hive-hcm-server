using Core.Events;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudyService.Application.Extensions;
using StudyService.Persistence.Extensions;
using StudyService.Web.Background;
using StudyService.Web.Consumer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.RegisterDatabase(builder.Configuration);
services.RegisterServices();

services.AddHostedService<DatabaseMigrationService>();

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
services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

services.AddMassTransit(x =>
{
    x.AddConsumer<CompanyCreatedConsumer>();
    x.AddConsumer<NewUserConsumer>();
    x.AddConsumer<UserUpdatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("new-user-study", e =>
        {
            e.ConfigureConsumer<NewUserConsumer>(context);
        });

        cfg.ReceiveEndpoint("company-created-study", e =>
        {
            e.ConfigureConsumer<CompanyCreatedConsumer>(context);
        });

        cfg.ReceiveEndpoint("user-update-study", e =>
        {
            e.ConfigureConsumer<UserUpdatedConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });
});

services.AddAuthorization();

services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "HiveHCM_Server",
        ValidAudience = "HiveHCM_Client",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("wqy8-2.cyEP{shJ1sp2r45TyuIU345]{mmadDG"))
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();

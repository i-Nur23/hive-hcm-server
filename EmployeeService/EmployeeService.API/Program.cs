using Core.Events;
using Core.Middlewares;
using EmployeeService.API.Background;
using EmployeeService.API.Consumers;
using EmployeeService.Application;
using EmployeeService.Persistence;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

services
    .AddControllers()
    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
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
    x.AddConsumer<CreateCompanyConsumer>();
    x.AddConsumer<CountriesScrapedConsumer>();
    x.AddConsumer<UserUpdatedConsumer>();
    x.AddConsumer<CandidateHireConsumer>();

    x.AddRequestClient<NewUserEvent>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("candidate-hire-employee", e =>
        {
            e.ConfigureConsumer<CandidateHireConsumer>(context);
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseCustomMiddlewares();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();

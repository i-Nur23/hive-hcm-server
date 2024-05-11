using Core.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoodService.Application;
using MoodService.Application.Common.Mappings;
using MoodService.Application.Interfaces;
using MoodService.Persistance;
using MoodService.Web.Consumers;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

var services = builder.Services;

services.AddMassTransitExtensions();
services.AddApplication();
services.AddPersistence(builder.Configuration);

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
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

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseCustomMiddlewares();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();

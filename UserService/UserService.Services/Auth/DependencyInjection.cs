using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserService.Models.Entities;
using UserService.Persistance;
using UserService.Services.Auth;
using UserService.Services.Auth.Interfaces;
using UserService.Web.Auth.Interfaces;

namespace UserService.Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IHashService, HashService>();

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

            return services;

        }
    }
}

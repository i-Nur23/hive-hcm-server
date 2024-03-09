using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserService.Web.Auth.Interfaces;

namespace UserService.Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "HiveHCM",
                ValidAudience = "HiveHCM",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("da432jkj)d--Dsdjrex756kkl7u555"))
            });

            return services;

        }
    }
}

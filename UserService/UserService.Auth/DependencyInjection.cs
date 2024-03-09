using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace UserService.Auth
{
    internal class DependencyInjection
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
                ValidIssuer = "KinoDrive",
                ValidAudience = "KinoDrive",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-key"))
            });

            return services;

        }
    }
}

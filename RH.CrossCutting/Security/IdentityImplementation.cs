using Microsoft.Extensions.DependencyInjection;

namespace RH.CrossCutting.Security
{
    public class IdentityImplementation
    {
        public static void SecurityImplementation(IServiceCollection services)
        {
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:7248/";
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "Erp");
                });
            });
        }
    }
}
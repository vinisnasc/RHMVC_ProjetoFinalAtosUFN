using Estoque.CrossCutting.Security;

namespace Estoque.Api.Configuration
{
    public static class SecurityConfiguration
    {
        public static IServiceCollection AddSecurityConfiguration(this IServiceCollection services)
        {
            IdentityImplementation.SecurityImplementation(services);
            return services;
        }

        public static WebApplication UseSecurityConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}

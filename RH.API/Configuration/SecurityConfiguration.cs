using RH.CrossCutting.Security;

namespace RH.API.Configuration
{
    public static class SecurityConfiguration
    {
        public static IServiceCollection AddSecurityConfiguration(this IServiceCollection services, IConfigurationBuilder configuration)
        {
            configuration.AddUserSecrets<Program>();
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
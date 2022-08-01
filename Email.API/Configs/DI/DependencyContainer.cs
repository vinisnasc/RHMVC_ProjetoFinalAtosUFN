using Email.API.Data.Context;
using Email.API.Data.Repository;
using Email.API.Services;
using Email.Domain.Configs;
using Email.Services.RabbitMQConsumer;

namespace Email.API.Configs.DI
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // DI
            services.AddSingleton<IEmailRepository, EmailRepository>();
            services.AddSingleton<IEmailContext, EmailContext>();

            // RabbitMQ
            services.AddHostedService<RabbitMQAdmissaoConsumer>();

            // Email
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddSingleton<IEmailService, EmailService>();
        }
    }
}
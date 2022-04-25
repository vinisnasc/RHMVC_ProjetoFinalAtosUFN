using Estoque.Data.Repository;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;
using Estoque.Services;
using Estoque.Services.RabbitMQConsumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.CrossCutting
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // Services
            services.AddScoped<IEpiService, EpiService>();
            services.AddScoped<IAlmoxarifadoService, AlmoxarifadoService>();
            services.AddScoped<IUniformeService, UniformeService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            // Repositorios
            services.AddTransient<IEpiRepository, EpiRepository>();
            services.AddTransient<IUniformeRepository, UniformeRepository>();
            services.AddTransient<IAlmoxarifadoRepository, AlmoxarifadoRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // UoW
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            // Rabbit
            services.AddHostedService<RabbitMQAdmissaoConsumer>();
        }
    }
}
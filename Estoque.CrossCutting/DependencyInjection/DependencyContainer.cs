using Estoque.Data.Repository;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;
using Estoque.Services;
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
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            // Repositorios
            services.AddTransient<IEpiRepository, EpiRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));   
        }
    }
}
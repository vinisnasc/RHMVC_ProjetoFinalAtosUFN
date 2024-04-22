using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RH.Data.Contexto;
using RH.Data.Repository;
using RH.Domain.Interfaces.Repository;
using RH.Domain.Interfaces.Services;
using RH.Domain.Interfaces.Services.RabbitMQ;
using RH.Services;
using RH.Services.RabbitMQSender;

namespace RH.CrossCutting
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            // Context
            services.AddDbContext<RhContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Services
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IFuncaoService, FuncaoService>();
            services.AddScoped<IPagamentosService, PagamentosService>();
            services.AddScoped<INotificador, Notificador>();

            // Repositorios
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IUfRepository, UfRepository>();
            services.AddScoped<IDecimoTerceiroRepository, DecimoTerceiroRepository>();
            services.AddScoped<IFeriasRepository, FeriasRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // RabbitMQ
            services.AddSingleton<IRabbitMQSender, RabbitMQSender>();
        }
    }
}
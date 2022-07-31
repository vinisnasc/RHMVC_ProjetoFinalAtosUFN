using KissLog;
using WEBAPP.MVC.Modulos.Estoque.Services;
using WEBAPP.MVC.Modulos.Estoque.Services.Interfaces;
using WEBAPP.MVC.Modulos.RecursosHumanos.Services;
using WEBAPP.MVC.Modulos.RecursosHumanos.Services.Interfaces;

namespace WEBAPP.MVC.Configs
{
    public static class DIConfig
    {
        public static void ResolveDependencias(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IDepartamentoService, DepartamentoService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RhApi"]));
            builder.Services.AddHttpClient<IFuncaoService, FuncaoService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RhApi"]));
            builder.Services.AddHttpClient<IFuncionarioService, FuncionarioService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RhApi"]));
            builder.Services.AddHttpClient<IEpiService, EpiService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EstoqueApi"]));
            builder.Services.AddHttpClient<IUniformeService, UniformeService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EstoqueApi"]));
            builder.Services.AddHttpClient<IAlmoxarifadoService, AlmoxarifadoService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EstoqueApi"]));
            builder.Services.AddHttpClient<IFuncionarioEstoqueService, FuncionarioEstoqueService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EstoqueApi"]));

            /*builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<ILogger>((context) =>
            {
                return (ILogger)Logger.Factory.Get();
            });*/
        }
    }
}
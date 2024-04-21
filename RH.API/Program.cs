using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RH.API.Configuration;
using RH.API.MIddlewares;
using RH.CrossCutting;
using RH.CrossCutting.Mappings;
using RH.Data.Contexto;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSecurityConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
DependencyContainer.RegisterServices(builder.Services,
                                     builder.Configuration.GetConnectionString("RHContext"));

builder.Services.AddDbContext<RhContext>(options =>
    options.UseSqlServer("RHContext"));

// Configuracao do AutoMapper
MapperConfiguration config = new(config =>
{
    config.AddProfile(new DtoToEntityProfile());
    config.AddProfile(new EntityToDtoProfile());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();
app.UseErrorMiddleware();
app.UseSwaggerConfiguration();
app.UseSecurityConfiguration();
app.MapControllers();
app.Run();
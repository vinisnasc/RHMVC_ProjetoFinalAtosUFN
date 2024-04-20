using AutoMapper;
using Estoque.Api.Configuration;
using Estoque.CrossCutting;
using Microsoft.EntityFrameworkCore;
using RH.CrossCutting.Mappings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Config Identity
builder.Services.AddSecurityConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

// Configuracao da injecao de dependencia
DependencyContainer.RegisterServices(builder.Services,
                                     builder.Configuration.GetConnectionString("EstoqueContext")!,
                                     builder.Configuration);

//Configuracao do AutoMapper
MapperConfiguration config = new(config =>
{
    config.AddProfile(new DtoToEntityProfile());
    config.AddProfile(new EntityToDtoProfile());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();
app.UseSwaggerConfiguration();
app.UseSecurityConfiguration();
app.MapControllers();
app.Run();
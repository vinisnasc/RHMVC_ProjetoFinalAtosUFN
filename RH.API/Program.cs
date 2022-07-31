using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RH.CrossCutting;
using RH.CrossCutting.Mappings;
using RH.CrossCutting.Security;
using RH.Data.Contexto;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Configuration.AddUserSecrets<Program>();

// Config Identity
IdentityImplementation.SecurityImplementation(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Erp.Rh.Api", });
    //c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Configuracao da injecao de dependencia
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
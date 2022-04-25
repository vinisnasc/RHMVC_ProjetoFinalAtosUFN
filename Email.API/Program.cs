using AutoMapper;
using Email.API.Configs.DI;
using Email.API.Configs.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Config DI
DependencyContainer.RegisterServices(builder.Services, builder.Configuration);

// Configuracao do AutoMapper
MapperConfiguration config = new(config =>
{
    config.AddProfile(new DtoToEntityProfile());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
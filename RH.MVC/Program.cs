using AutoMapper;
using RH.CrossCutting;
using RH.CrossCutting.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração da injeção de dependencia
DependencyContainer.RegisterServices(builder.Services,
                                     builder.Configuration.GetConnectionString("RHContext"),
                                     builder.Configuration);

// Configuração do AutoMapper
MapperConfiguration config = new(config =>
{
    config.AddProfile(new DtoToEntityProfile());
    config.AddProfile(new EntityToDtoProfile());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

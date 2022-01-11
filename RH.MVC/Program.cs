using AutoMapper;
using RH.CrossCutting;
using RH.CrossCutting.Mappings;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Services;
using RH.Services;

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

// Configuração do SendGrid
builder.Services.AddTransient<IEmailSender, SendGridEmailService>();
builder.Services.Configure<SendGridEmailSenderOptions>(options =>
{
    options.ApiKey = builder.Configuration["ExternalProviders:SendGrid:ApiKey"];
    options.SenderEmail = builder.Configuration["ExternalProviders:SendGrid:SenderEmail"];
    options.SenderName = builder.Configuration["ExternalProviders:SendGrid:SenderName"];
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

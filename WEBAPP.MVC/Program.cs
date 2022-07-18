using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Razor;
using WEBAPP.MVC.Modulos.RecursosHumanos.Services;
using WEBAPP.MVC.Modulos.RecursosHumanos.Services.Interfaces;
using WEBAPP.MVC.Services;
using WEBAPP.MVC.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Config Identity Server
var result = builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", options =>
  {
      options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
      options.GetClaimsFromUserInfoEndpoint = true;
      options.ClientId = "erp";
      options.ClientSecret = "secret";
      options.ResponseType = "code";
      options.ClaimActions.MapJsonKey("role", "role", "role");
      options.ClaimActions.MapJsonKey("sub", "sub", "sub");
      options.TokenValidationParameters.NameClaimType = "name";
      options.TokenValidationParameters.RoleClaimType = "role";
      options.Scope.Add("Erp");
      options.SaveTokens = true;
  });

// Injecao de dependencia
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

// Configuração de Areas
// Observação: Essa configuração serve para caso o nome da pasta de Areas seja alterado
// Caso o nome seja Areas mesmo, não é necessário fazer essa configuração
// Nesse exemplo, utilizei o nome "Modulos"
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
//app.MapAreaControllerRoute("AreaRecursosHumanos", "RecursosHumanos", "RecursosHumanos/{controller=Funcao}/{action=Index}/{id?}");

app.Run();
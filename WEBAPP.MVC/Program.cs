using Microsoft.AspNetCore.Authentication;
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
builder.Services.AddHttpClient<IFuncionarioEstoqueService, FuncionarioEstoqueService>(c =>
c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EstoqueApi"]));

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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

using KissLog.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using WEBAPP.MVC.Configs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

IdentityConfig.AddIdentityConfig(builder);
DIConfig.ResolveDependencias(builder);
builder.Services.RegisterKissLogListeners();

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
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

//app.UseKissLogMiddleware();
app.RegisterKissLogListeners(builder.Configuration);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
//app.MapAreaControllerRoute("AreaRecursosHumanos", "RecursosHumanos", "RecursosHumanos/{controller=Funcao}/{action=Index}/{id?}");

app.Run();
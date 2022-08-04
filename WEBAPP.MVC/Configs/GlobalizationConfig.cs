using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WEBAPP.MVC.Configs
{
    public static class GlobalizationConfig
    {
        public static IApplicationBuilder AddGlobalizationConfig(this IApplicationBuilder app)
        {
            // Essa configuração não altera o javascript, para alterar o js, verificar _ValidationScriptsPartial na pasta Shared
            var defaultCulture = new CultureInfo("pt-Br");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);

            return app;
        }
    }
}
using Microsoft.AspNetCore.Authentication;

namespace WEBAPP.MVC.Configs
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
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
        }
    }
}
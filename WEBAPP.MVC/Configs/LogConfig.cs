using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;

namespace WEBAPP.MVC.Configs
{
    public static class LogConfig
    {
        public static void RegisterKissLogListeners(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());

            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });
        }

        public static void RegisterKissLogListeners(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseKissLogMiddleware(options => ConfigureKissLog(options, configuration));
        }

        private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            KissLogConfiguration.Listeners
                .Add(new RequestLogsApiListener(new Application(configuration["KissLog.OrganizationId"], configuration["KissLog.ApplicationId"]))
                {
                    ApiUrl = configuration["KissLog.ApiUrl"]
                });
        }
    }
}
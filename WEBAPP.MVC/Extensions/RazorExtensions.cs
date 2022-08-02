using Microsoft.AspNetCore.Mvc.Razor;

namespace WEBAPP.MVC.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataCPF(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
        }
    }
}
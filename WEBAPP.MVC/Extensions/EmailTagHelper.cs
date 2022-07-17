using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WEBAPP.MVC.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "hotmail.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);

            // Lembrar de importar para o _ViewImports
            // chamada da taghelper no html é sempre minuscula, e se tiver duas palavras, separar por traço:
            // EmailTesteTagHelper => <email-teste>

        }
    }
}

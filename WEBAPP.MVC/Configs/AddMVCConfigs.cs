namespace WEBAPP.MVC.Configs
{
    public static class AddMVCConfigs
    {
        public static IServiceCollection AddMVCConfiguration(this IServiceCollection services)
        {
            // Configurações de linguagem do MVC
            services.AddMvc(o =>
            {
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor preenchido é invalido para este campo!");
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor((x) => "Este campo deve ser preenchido");
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Este campo deve ser preenchido");
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "É necessario que o body na requqisição não esteja vazio");
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => "O valor preenchido é invalido para este campo");
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor preenchido é invalido para este campo");
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser numérico");
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => "O valor preenchido é invalido para este campo");
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => "O valor preenchido é invalido para este campo");
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((x) => "O campo deve ser numérico");
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) => "Este campo deve ser preenchido");
            });
            return services;
        }
    }
}

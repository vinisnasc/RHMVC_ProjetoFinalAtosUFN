using RH.Domain.Dtos.Responses;

namespace RH.Domain.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string templateId, TemplateData templateData);
    }
}

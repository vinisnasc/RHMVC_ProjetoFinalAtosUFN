using Microsoft.Extensions.Options;
using RH.Domain.Dtos.Responses;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace RH.Services
{
    public class SendGridEmailService : IEmailSender
    {
        public SendGridEmailService(IOptions<SendGridEmailSenderOptions> options)
        {
            this.Options = options.Value;
        }

        public SendGridEmailSenderOptions Options { get; set; }

        public async Task SendEmailAsync(string email, string subject, string templateId, TemplateData templateData)
        {
            await Execute(Options.ApiKey, subject, templateId, templateData, email);
        }

        private async Task<Response> Execute(string apiKey, string subject, string templateId, TemplateData templateData, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SenderName),
                Subject = subject
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetTemplateId(templateId);
            msg.SetTemplateData(templateData);
            msg.SetClickTracking(false, false);
            msg.SetOpenTracking(false);
            msg.SetGoogleAnalytics(false);
            msg.SetSubscriptionTracking(false);
            return await client.SendEmailAsync(msg);
        }
    }
}

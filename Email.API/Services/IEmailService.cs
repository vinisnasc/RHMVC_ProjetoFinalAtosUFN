using Email.Domain.Configs;

namespace Email.API.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
        void SaveEmail(Message message);
    }
}

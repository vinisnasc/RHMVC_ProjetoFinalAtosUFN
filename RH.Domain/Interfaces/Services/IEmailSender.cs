using RH.Domain.Entities.Email;

namespace RH.Domain.Interfaces.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
        void SaveEmail(Message message);
    }
}

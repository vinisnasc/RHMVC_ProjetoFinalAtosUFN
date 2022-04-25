using Email.API.Domain.Entities;

namespace Email.API.Data.Repository
{
    public interface IEmailRepository
    {
        Task SaveEmailLog(EmailLog email);
    }
}

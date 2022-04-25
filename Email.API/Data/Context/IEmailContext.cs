using Email.API.Domain.Entities;
using MongoDB.Driver;

namespace Email.API.Data.Context
{
    public interface IEmailContext
    {
        IMongoCollection<EmailLog> Emails { get; }
    }
}

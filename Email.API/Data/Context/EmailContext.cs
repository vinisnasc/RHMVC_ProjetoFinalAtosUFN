using Email.API.Domain.Entities;
using MongoDB.Driver;

namespace Email.API.Data.Context
{
    public class EmailContext : IEmailContext
    {
        public IMongoCollection<EmailLog> Emails { get; }

        public EmailContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Emails = database.GetCollection<EmailLog>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
    }
}

using Email.API.Data.Context;
using Email.API.Domain.Entities;

namespace Email.API.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IEmailContext _context;

        public EmailRepository(IEmailContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveEmailLog(EmailLog email)
        {
            await _context.Emails.InsertOneAsync(email);
        }
    }
}

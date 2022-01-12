using MimeKit;

namespace RH.Domain.Entities.Email
{
    public class Message
    {
        public MailboxAddress Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Message(string destinatario, string assunto,
            string conteudo)
        {
            Destinatario = new MailboxAddress(destinatario);
            Assunto = assunto;
            Conteudo = conteudo;
        }
    }
}

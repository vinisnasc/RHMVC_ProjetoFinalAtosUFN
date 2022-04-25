using MimeKit;

namespace Email.Domain.Configs
{
    public class Message
    {
        // NETCore.MailKit 2.0.3
        public MailboxAddress Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Message(string destinatario, string assunto,
            string conteudo)
        {
            Destinatario = new MailboxAddress(destinatario, destinatario);
            Assunto = assunto;
            Conteudo = conteudo;
        }
    }
}

using Email.Domain.Configs;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.IO;

namespace Email.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SaveEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            SaveToPickupDirectory(emailMessage, _emailConfig.DiretorioLocal);
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("RH Sua Empresa", _emailConfig.Remetente));
            emailMessage.To.Add(message.Destinatario);
            emailMessage.Subject = message.Assunto;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Conteudo };
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Porta, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.Usuario, _emailConfig.Senha);
                    client.Send(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Porta, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.Usuario, _emailConfig.Senha);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private static void SaveToPickupDirectory(MimeMessage message, string pickupDirectory)
        {
            do
            {
                var path = Path.Combine(pickupDirectory, Guid.NewGuid().ToString() + ".eml");
                Stream stream;

                try
                {
                    stream = File.Open(path, FileMode.CreateNew);
                }
                catch (IOException)
                {
                    if (File.Exists(path))
                        continue;

                    throw;
                }

                try
                {
                    using (stream)
                    {
                        using (var filtered = new FilteredStream(stream))
                        {
                            filtered.Add(new SmtpDataFilter());

                            var options = FormatOptions.Default.Clone();
                            options.NewLineFormat = NewLineFormat.Dos;

                            message.WriteTo(options, filtered);
                            filtered.Flush();
                            return;
                        }
                    }
                }
                catch
                {
                    File.Delete(path);
                    throw;
                }
            } while (true);
        }
    }
}

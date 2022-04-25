using MessageBus;
using RabbitMQ.Client;
using RH.Domain.Interfaces.Services.RabbitMQ;
using RH.Domain.Menssagem;
using System.Text;
using System.Text.Json;

namespace RH.Services.RabbitMQSender
{
    public class RabbitMQSender : IRabbitMQSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        private const string ExchangeName = "FanoutAdmissaoExchange";

        public RabbitMQSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

      public void SendMessage(BaseMessage message)
        {
            if(ConnectionExists())
            {
                using var channel = _connection.CreateModel();

                channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, durable: false);
                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(exchange: ExchangeName, routingKey: "", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                // Essa option permite a serialização de classes filhas
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize<AdmissaoMessage>((AdmissaoMessage)message, options);
            return Encoding.UTF8.GetBytes(json);
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
                return true;

            CreateConnection();

            return _connection != null;
        }
    }
}

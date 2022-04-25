using AutoMapper;
using Email.API.Data.Repository;
using Email.API.Domain.DTOs.Messages;
using Email.API.Domain.Entities;
using Email.API.Services;
using Email.Domain.Configs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Email.Services.RabbitMQConsumer
{
    public class RabbitMQAdmissaoConsumer : BackgroundService
    {
        private readonly IMapper _mapper;
        private readonly IEmailRepository _repository;
        private readonly IEmailService _emailService;
        private IConnection _connection;
        private IModel _channel;
        private const string ExchangeName = "FanoutAdmissaoExchange";
        string queueName = "";

        public RabbitMQAdmissaoConsumer(IMapper mapper, IEmailRepository repository, IEmailService emailService)
        {
            _mapper = mapper;
            _repository = repository;
            _emailService = emailService;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout);
            queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queueName, ExchangeName, "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                AdmissaoMessage message = JsonSerializer.Deserialize<AdmissaoMessage>(content);
                ProcessLogs(message).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(queueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessLogs(AdmissaoMessage message)
        {
            try
            {
                var conteudo = System.IO.File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Template\\Admissao.cshtml");
                conteudo = conteudo.Replace("{{username}}", message.Nome);
                Message email = new Message(message.Email, message.AssuntoEmail, conteudo);
                await _emailService.SendEmailAsync(email);

                EmailLog entity = _mapper.Map<EmailLog>(message);
                entity.DataEnvio = DateTime.Now;
                await _repository.SaveEmailLog(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
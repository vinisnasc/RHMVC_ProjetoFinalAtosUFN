using System.Text;
using System.Text.Json;
using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto.Messages;
using Estoque.Domain.Interfaces.Repository;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Estoque.Services.RabbitMQConsumer
{
    public class RabbitMQAdmissaoConsumer : BackgroundService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IConnection _connection;
        private IModel _channel;
        private const string ExchangeName = "FanoutAdmissaoExchange";
        string queueName = "";

        public RabbitMQAdmissaoConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            // todo: ocorrendo erro aqui
            //_connection = factory.CreateConnection();
            //_channel = _connection.CreateModel();
            //_channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout);
            //queueName = _channel.QueueDeclare().QueueName;
            //_channel.QueueBind(queueName, ExchangeName, "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                AdmissaoDto dto = JsonSerializer.Deserialize<AdmissaoDto>(content)!;
                ProcessOrder(dto).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            // todo: ocorrendo erro aqui
            //_channel.BasicConsume(queueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessOrder(AdmissaoDto dto)
        {
            try
            {
                Funcionario func = _mapper.Map<Funcionario>(dto);
                await _unitOfWork.FuncionarioRepository.Incluir(func);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
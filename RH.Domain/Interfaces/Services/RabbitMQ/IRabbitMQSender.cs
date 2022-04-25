using MessageBus;

namespace RH.Domain.Interfaces.Services.RabbitMQ
{
    public interface IRabbitMQSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}

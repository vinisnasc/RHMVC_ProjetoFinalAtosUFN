namespace MessageBus
{
    public class BaseMessage
    {
        public Guid Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
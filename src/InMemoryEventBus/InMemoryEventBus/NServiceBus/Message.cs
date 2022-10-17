using NServiceBus;

namespace InMemoryEventBus.NServiceBus
{
    public class Message:ICommand
    {
        public int MessageId { get; set; }
    }
}

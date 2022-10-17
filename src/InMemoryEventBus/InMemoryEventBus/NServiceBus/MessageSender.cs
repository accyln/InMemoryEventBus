using NServiceBus;

namespace InMemoryEventBus.NServiceBus
{
    public class MessageSender
    {
        public async Task SendMessage(IMessageSession messageSession) 
        {
           await messageSession.SendLocal(new Message() { MessageId = 11 });

        }
    }
}

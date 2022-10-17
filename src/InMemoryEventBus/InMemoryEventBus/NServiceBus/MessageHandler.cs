using NServiceBus;

namespace InMemoryEventBus.NServiceBus
{
    public class MessageHandler : IHandleMessages<Message>
    {
        public Task Handle(Message message, IMessageHandlerContext context)
        {
            Thread.Sleep(5);

            Console.WriteLine("Message taken : "+ message.MessageId);

            return Task.CompletedTask;
        }
    }
}

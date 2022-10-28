using InMemoryEventBus.EventDrivenClearArc.EventArg;

namespace InMemoryEventBus.EventDrivenClearArc
{
    public class ConsumerService
    {
        public void CreateSomething(object source, CreateSomethingEventArg eventArgs)
        {
            Console.WriteLine($"AppService: your food '{eventArgs.ARequest.Id}' is prepared.");
        }
    }
}

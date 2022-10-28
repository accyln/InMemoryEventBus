using EventQueueWithMassTransit.EventBus.Event;

namespace EventQueueWithMassTransit.EventBus
{
    public class SomePublisher
    {
        public event EventHandler<DoSomethingEventArg> Doit;
        public async Task DoSomethingPublisher()
        {
            Doit.Invoke(this,new DoSomethingEventArg() { Name="Ahandaaaa"});
        }
    }
}

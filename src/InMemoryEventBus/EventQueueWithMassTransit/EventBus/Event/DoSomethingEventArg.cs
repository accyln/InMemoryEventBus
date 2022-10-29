using EventQueueWithMassTransit.DataContext;

namespace EventQueueWithMassTransit.EventBus.Event
{
    public class DoSomethingEventArg:EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

 
}

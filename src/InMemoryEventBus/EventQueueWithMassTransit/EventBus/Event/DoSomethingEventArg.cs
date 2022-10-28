namespace EventQueueWithMassTransit.EventBus.Event
{
    public class DoSomethingEventArg:EventArgs
    {
        public string Name { get; set; }
    }
}

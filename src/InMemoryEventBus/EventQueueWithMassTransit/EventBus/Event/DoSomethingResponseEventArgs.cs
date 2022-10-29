namespace EventQueueWithMassTransit.EventBus.Event
{
    public class DoSomethingResponseEventArgs:EventArgs
    {
        public int Id { get; set; }
        public bool Result { get; set; }
    }
}

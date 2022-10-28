using InMemoryEventBus.EventDrivenClearArc.Entity;

namespace InMemoryEventBus.EventDrivenClearArc.EventArg
{
    public class CreateSomethingEventArg:EventArgs
    {
        public RequestEntity ARequest { get; set; }
    }
}

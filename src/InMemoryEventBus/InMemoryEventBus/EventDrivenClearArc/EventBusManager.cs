namespace InMemoryEventBus.EventDrivenClearArc
{
    public class EventBusManager : IEventBus
    {
        public void Publish<TEvent>(TEvent @event) where TEvent : BaseEvent
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : BaseEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }
    }
}

using InMemoryEventBus.Entity;

namespace InMemoryEventBus.EventBus
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : BaseEvent;

        void Subscribe<TEvent, TEventHandler>() where TEvent : BaseEvent where TEventHandler : IEventHandler<TEvent>;

        void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : BaseEvent
            where TEventHandler : IEventHandler<TEvent>;
    }
}

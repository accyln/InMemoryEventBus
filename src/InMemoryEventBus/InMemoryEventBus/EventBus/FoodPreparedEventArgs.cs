using InMemoryEventBus.Entity;

namespace InMemoryEventBus.EventBus
{
    public class FoodPreparedEventArgs:EventArgs
    {
        public Order Order { get; set; }
    }
}

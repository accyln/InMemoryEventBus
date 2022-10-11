using InMemoryEventBus.Entity;
using InMemoryEventBus.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryEventBus.Services
{
    public class FoodOrderingService
    {
        public event EventHandler<FoodPreparedEventArgs> FoodPrepared;
        public void PrepareOrder(Order order)
        {
            Console.WriteLine($"Preparing your order '{order.Item}', please wait...");
            Thread.Sleep(4000);
            OnFoodPrepared(order);
        }
        protected virtual void OnFoodPrepared(Order order)
        {
            FoodPrepared?.Invoke(this, new FoodPreparedEventArgs { Order = order });
        }
    }
}

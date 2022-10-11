using InMemoryEventBus.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryEventBus.Services
{
    public class AppService
    {
        public void OnFoodPrepared(object source, FoodPreparedEventArgs eventArgs)
        {
            Console.WriteLine($"AppService: your food '{eventArgs.Order.Item}' is prepared.");
        }
    }
}

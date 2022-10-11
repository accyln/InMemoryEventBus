using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryEventBus.Entity
{
    public class Event2
    {
        public void OnFoodPrepared(object source, EventArgs eventArgs)
        {
            Console.WriteLine("AppService: your food is prepared.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryEventBus.Entity
{
    public class Order
    {
        public string Item { get; set; }
        public string Ingredients { get; set; }
    }
}

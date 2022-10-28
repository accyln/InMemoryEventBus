using EventQueueWithMassTransit.EventBus.Event;

namespace EventQueueWithMassTransit.EventBus
{
    public class SomeConsumer
    {
        public void DoSomething(object source,DoSomethingEventArg doSomethingEventArg) {

            Thread.Sleep(1000);


            Console.WriteLine($"AppService: your food '{doSomethingEventArg.Name}' is consumed.");

            Thread.Sleep(1000);


        }
    }
}

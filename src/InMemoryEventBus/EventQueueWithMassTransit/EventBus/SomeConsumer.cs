using EventQueueWithMassTransit.EventBus.Event;
using EventQueueWithMassTransit.Services;

namespace EventQueueWithMassTransit.EventBus
{
    public class SomeConsumer
    {
        private DefaultService defaultService;
        public SomeConsumer(DefaultService defaultService)
        {
            this.defaultService = defaultService;
        }
        public event EventHandler<DoSomethingResponseEventArgs> DoitResponse;
        public async void DoSomething(object source,DoSomethingEventArg doSomethingEventArg) {


            var result=await defaultService.DoSomethingLongJob(doSomethingEventArg);

            

        }
    }
}

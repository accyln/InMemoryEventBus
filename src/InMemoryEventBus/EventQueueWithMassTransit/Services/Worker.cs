using EventQueueWithMassTransit.Contracts;
using EventQueueWithMassTransit.EventBus;
using MassTransit;

namespace EventQueueWithMassTransit.Services
{
    public class Worker : BackgroundService
    {
        protected IBus _bus;
        protected SomePublisher somePublisher;
        protected SomeConsumer someConsumer;

        public Worker(IBus bus, SomePublisher somePublisher, SomeConsumer someConsumer)
        {
            _bus = bus;
            this.somePublisher = somePublisher;
            this.someConsumer = someConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            somePublisher.Doit += someConsumer.DoSomething;
            while (!stoppingToken.IsCancellationRequested)
            {
                await somePublisher.DoSomethingPublisher();

                await _bus.Publish(new CreatePipeline() 
                { 
                    PipelineName = "Acc" 
                }, stoppingToken);

                

                await Task.Delay(1000,stoppingToken);
            }
        }
    }
}

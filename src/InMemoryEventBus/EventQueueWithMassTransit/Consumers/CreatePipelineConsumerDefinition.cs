using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace EventQueueWithMassTransit.Consumers
{
    public class CreatePipelineConsumerDefinition:ConsumerDefinition<CreatePipelineConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<CreatePipelineConsumer> consumerConfigurator)
        {
            base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);

            //endpointConfigurator.UseMessageRetry(r => r.Interavals(500, 1000));
        }
    }
}

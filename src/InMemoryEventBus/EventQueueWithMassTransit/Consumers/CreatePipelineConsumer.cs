using EventQueueWithMassTransit.Contracts;
using MassTransit;

namespace EventQueueWithMassTransit.Consumers
{
    public class CreatePipelineConsumer : IConsumer<CreatePipeline>
    {
        private readonly ILogger<CreatePipelineConsumer> _logger;
        public CreatePipelineConsumer(ILogger<CreatePipelineConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatePipeline> context)
        {
            _logger.LogInformation("Event consumed" + context.Message.PipelineName);

            

            await Task.CompletedTask;

            await context.RespondAsync<CreatePipeline>(new CreatePipeline() { PipelineName="Al sana response"});
        }
    }
}

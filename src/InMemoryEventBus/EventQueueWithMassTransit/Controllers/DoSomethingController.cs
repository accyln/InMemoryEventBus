using EventQueueWithMassTransit.Contracts;
using EventQueueWithMassTransit.EventBus;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventQueueWithMassTransit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoSomethingController : ControllerBase
    {
        private SomePublisher somePublisher;
        private SomeConsumer someConsumer;
        protected IBus _bus;
        public DoSomethingController( IBus bus, SomePublisher somePublisher, SomeConsumer someConsumer)
        {
            _bus = bus;
            this.somePublisher = somePublisher;
            this.someConsumer = someConsumer;
        }

        [HttpGet]
        public async Task<ActionResult> CreatePipeline()
        {
            somePublisher.Doit += someConsumer.DoSomething;
            await somePublisher.DoSomethingPublisher();

            return Ok();
        }
    }
}

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
        private readonly IRequestClient<CreatePipeline> _client;

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

        [HttpPost]
        [Route("long-running-task")]
        public async Task<ActionResult> Run()
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/event-stream";
            Response.ContentLength = 10;

            var sw = new StreamWriter(Response.Body);

            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                await sw.WriteAsync("1");
                await sw.FlushAsync();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> MassTransitRequest()
        {
          

            return Ok();
        }
    }
}

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
        DataContext.DataContext _dataContext;

        public DoSomethingController( IBus bus, SomePublisher somePublisher, SomeConsumer someConsumer, DataContext.DataContext dataContext)
        {
            _bus = bus;
            this.somePublisher = somePublisher;
            this.someConsumer = someConsumer;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> CreatePipeline()
        {
            somePublisher.Doit += someConsumer.DoSomething;
            var result=await somePublisher.DoSomethingPublisher();

            return Ok(result);
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


        [HttpGet]
        [Route("Get")]
        public async Task Get()
        {
            var response = Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            var runs = _dataContext.TestRuns.ToList();
            foreach (var run in runs)
            {
                await response
                    .WriteAsync($"data: Controller {run.RunCode} at {DateTime.Now}\r\r");

                response.Body.Flush();
                await Task.Delay(5 * 1000);
            }
        }
    }
}

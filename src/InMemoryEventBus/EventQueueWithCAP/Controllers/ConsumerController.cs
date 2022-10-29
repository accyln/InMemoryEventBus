using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventQueueWithCAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;
        private readonly DataContext.DataContext _dataContext;
        public ConsumerController(ICapPublisher capPublisher, DataContext.DataContext dataContext)
        {
            _capPublisher = capPublisher;
            _dataContext = dataContext;
        }

        [NonAction]
        [CapSubscribe("xxx.services.show.time")]
        public void ReceiveMessage(DateTime time)
        {
            Console.WriteLine("message time is:" + time);

            _capPublisher.Publish("xxx.createPipelineResult", true);
        }
    }
}

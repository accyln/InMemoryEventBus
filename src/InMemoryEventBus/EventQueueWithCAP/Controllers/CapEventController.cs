using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventQueueWithCAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapEventController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;
        private readonly DataContext.DataContext _dataContext;
        public CapEventController(ICapPublisher capPublisher,DataContext.DataContext dataContext)
        {
            _capPublisher = capPublisher;
            _dataContext = dataContext;
        }
        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {

            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? trans = _dataContext.Database.BeginTransaction(_capPublisher, autoCommit: true))
            {
                // This is where you would do other work that is going to persist data to your database

                   _capPublisher.Publish("xxx.services.show.time", DateTime.Now);
   
            }


            return Ok();
        }
        
    }
}

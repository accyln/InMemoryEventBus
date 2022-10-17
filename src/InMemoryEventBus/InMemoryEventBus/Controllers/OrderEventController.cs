using InMemoryEventBus.Entity;
using InMemoryEventBus.NServiceBus;
using InMemoryEventBus.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryEventBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderEventController : ControllerBase
    {
        MessageSender messageSender;
        IMessageSession messageSession;
        public OrderEventController(MessageSender messageSender, IMessageSession messageSession)
        {
            this.messageSender = messageSender;
           this.messageSession = messageSession;
        }

        [Route("RunEvent")]
        [HttpGet]
        public async Task<ActionResult> RunEvent()
        {
            var order = new Order { Item = "Pizza with extra cheese" };
            var orderingService = new FoodOrderingService();
            var appService = new AppService();
            orderingService.FoodPrepared += appService.OnFoodPrepared;
            orderingService.PrepareOrder(order);

            return Ok(order);
        }


        [Route("SendMessage")]
        [HttpGet]
        public async Task<ActionResult> SendMessage()
        {
            await messageSender.SendMessage(messageSession);

            return Ok();
        }
    }
}

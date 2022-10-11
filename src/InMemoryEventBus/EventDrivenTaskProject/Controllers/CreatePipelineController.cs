using EventDrivenTaskProject.Features.DoTask.Commands.CreatePipeline;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenTaskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePipelineController : ControllerBase
    {
        IMediator mediator;
        public CreatePipelineController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Route("CreatePipe")]
        public async Task<ActionResult> CreatePipe()
        {
            return Ok(await mediator.Send(new CreatePipelineCommand() { PipelineName = "Acc" }));
        }
    }
}

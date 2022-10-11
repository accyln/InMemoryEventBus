using EventDrivenTaskProject.Entities;
using MediatR;

namespace EventDrivenTaskProject.Features.DoTask.Commands.CreatePipeline
{
    public class CreatePipelineCommand: IRequest<Result<TaskResponse>>
    {
        public string PipelineName { get; set; }
    }
}

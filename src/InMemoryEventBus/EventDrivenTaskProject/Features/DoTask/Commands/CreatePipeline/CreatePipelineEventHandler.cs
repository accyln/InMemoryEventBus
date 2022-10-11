using EventDrivenTaskProject.Entities;
using MediatR;

namespace EventDrivenTaskProject.Features.DoTask.Commands.CreatePipeline
{
    public class CreatePipelineEventHandler : IRequestHandler<CreatePipelineCommand, Result<TaskResponse>>
    {
        public async Task<Result<TaskResponse>> Handle(CreatePipelineCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return new Result<TaskResponse> { ErrorCode = 200, IsSuccess = true, ResultValue = new TaskResponse() { Response = "Pipeline Created" } };
        }
    }
}

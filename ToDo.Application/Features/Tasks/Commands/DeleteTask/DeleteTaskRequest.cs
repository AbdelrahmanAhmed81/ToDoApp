using Ardalis.Result;
using MediatR;

namespace ToDo.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<Result<bool>>
    {
        public Guid TaskId { get; set; }
    }
}

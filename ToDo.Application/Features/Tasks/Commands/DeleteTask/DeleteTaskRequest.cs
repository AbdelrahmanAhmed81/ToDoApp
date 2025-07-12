using Ardalis.Result;
using MediatR;
using ToDo.Application.Common;

namespace ToDo.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : UserRequest, IRequest<Result<bool>>
    {
        public Guid TaskId { get; set; }
    }
}

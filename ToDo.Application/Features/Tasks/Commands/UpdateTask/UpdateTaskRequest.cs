using Ardalis.Result;
using MediatR;
using ToDo.Application.Common;
using ToDo.Application.DTOs;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequest : UserRequest, IRequest<Result<bool>>
    {
        public UpdateTaskDTO UpdateTaskDTO { get; set; }
    }
}

using Ardalis.Result;
using MediatR;
using ToDo.Application.Common;
using ToDo.Application.DTOs;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskRequest : UserRequest, IRequest<Result<bool>>
    {
        public CreateTaskDTO CreateTaskDTO { get; set; }
    }
}

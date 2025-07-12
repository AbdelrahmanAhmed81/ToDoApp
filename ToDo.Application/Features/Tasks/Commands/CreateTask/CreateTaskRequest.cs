using Ardalis.Result;
using MediatR;
using ToDo.Application.DTOs;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskRequest : IRequest<Result<bool>>
    {
        public Guid RequestSenderUserId { get; set; }
        public CreateTaskDTO CreateTaskDTO { get; set; }
    }
}

using Ardalis.Result;
using MediatR;
using ToDo.Application.DTOs;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequest : IRequest<Result<bool>>
    {
        public Guid RequestSenderUserId { get; set; }
        public UpdateTaskDTO UpdateTaskDTO { get; set; }
    }
}

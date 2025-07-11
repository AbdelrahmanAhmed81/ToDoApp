using Ardalis.Result;
using MediatR;
using ToDo.Application.DTOs;

namespace ToDo.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public class GetTasksByUserIdRequest : IRequest<Result<IEnumerable<TaskDTO>>>
    {
        public Guid UserId { get; set; }
    }
}

using Ardalis.Result;
using MediatR;
using ToDo.Application.Common;
using ToDo.Application.DTOs;

namespace ToDo.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public class GetTasksByUserIdRequest : UserRequest, IRequest<Result<IEnumerable<TaskDTO>>>
    {
    }
}

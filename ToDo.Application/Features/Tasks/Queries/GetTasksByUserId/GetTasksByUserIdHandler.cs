using Ardalis.Result;
using AutoMapper;
using MediatR;
using ToDo.Application.Contracts.Repositories;
using ToDo.Application.DTOs;


namespace ToDo.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public class GetTasksByUserIdHandler : IRequestHandler<GetTasksByUserIdRequest, Result<IEnumerable<TaskDTO>>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksByUserIdHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<TaskDTO>>> Handle(GetTasksByUserIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userTaks = await _taskRepository.GetTasksByUserIdAsync(request.UserId);
                if (userTaks == null || !userTaks.Any())
                {
                    return Result.NoContent();
                }
                var result = _mapper.Map<IEnumerable<TaskDTO>>(userTaks);
                return Result.Success(result);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("An error occured while fetching user tasks");
            }

        }
    }
}

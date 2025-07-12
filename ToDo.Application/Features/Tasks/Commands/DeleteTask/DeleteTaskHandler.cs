using Ardalis.Result;
using AutoMapper;
using MediatR;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequest, Result<bool>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public DeleteTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(request.TaskId);
                if (task is null)
                {
                    return Result.Invalid(new ValidationError($"Task with Id {request.TaskId} not found"));
                }

                var deletionResult = await _taskRepository.DeleteAsync(task);
                if (!deletionResult)
                    return Result.Error($"Failed to delete task with Id {request.TaskId}");

                return Result.Success(deletionResult);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("an error occured while deleteing task");
            }
        }
    }
}

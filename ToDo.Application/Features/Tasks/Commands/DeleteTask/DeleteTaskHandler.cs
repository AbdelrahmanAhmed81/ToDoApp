using Ardalis.Result;
using MediatR;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequest, Result<bool>>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
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

                if (task.UserId != request.RequestSenderUserId)
                {
                    return Result.Unauthorized($"User has no access to manage this content");
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

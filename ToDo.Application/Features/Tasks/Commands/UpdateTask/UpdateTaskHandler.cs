using Ardalis.Result;
using AutoMapper;
using MediatR;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, Result<bool>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly UpdateTaskValidator _requestValidator;

        public UpdateTaskHandler(ITaskRepository taskRepository, IMapper mapper, UpdateTaskValidator requestValidator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _requestValidator = requestValidator;
        }

        public async Task<Result<bool>> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _requestValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result.Invalid(validationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)));
                }

                var taskEntity = _mapper.Map<TaskEntity>(request.UpdateTaskDTO);
                taskEntity.UserId = request.RequestSenderUserId;

                var updatingResult = await _taskRepository.UpdateAsync(taskEntity);

                if (!updatingResult)
                    return Result.Error($"Failed to update task with id {request.UpdateTaskDTO.ID}");

                return Result.Created(updatingResult);
            }
            catch (Exception ex)
            {
                return Result.CriticalError($"an error occured while updating task with id {request.UpdateTaskDTO.ID}");
            }
        }
    }
}

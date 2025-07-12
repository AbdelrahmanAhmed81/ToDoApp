using Ardalis.Result;
using AutoMapper;
using MediatR;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskRequest, Result<bool>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly CreateTaskValidator _requestValidator;

        public CreateTaskHandler(ITaskRepository taskRepository, IMapper mapper, CreateTaskValidator requestValidator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _requestValidator = requestValidator;
        }

        public async Task<Result<bool>> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validatationResult = await _requestValidator.ValidateAsync(request, cancellationToken);
                if (!validatationResult.IsValid)
                {
                    return Result.Invalid(validatationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)));
                }

                var taskEntity = _mapper.Map<TaskEntity>(request.CreateTaskDTO);
                var creationResult = await _taskRepository.AddAsync(taskEntity);

                if (!creationResult)
                    return Result.Error("Failed to create new task");

                return Result.Created(creationResult);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("an error occured while creating user task");
            }
        }
    }
}

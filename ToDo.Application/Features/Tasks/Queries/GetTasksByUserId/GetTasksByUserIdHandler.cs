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
        private readonly GetTasksByUserIdValidator _validator;
        private readonly IMapper _mapper;

        public GetTasksByUserIdHandler(ITaskRepository taskRepository,GetTasksByUserIdValidator validator, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<TaskDTO>>> Handle(GetTasksByUserIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result.Invalid(validationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)));
                }

                var userTaks = await _taskRepository.GetTasksByUserIdAsync(request.RequestSenderUserId);
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

using FluentValidation;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public UpdateTaskValidator(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;

            RuleFor(request => request.RequestSenderUserId)
                .MustAsync(_userRepository.IsUserExistsAsync).WithMessage("User not found");

            RuleFor(request => request.UpdateTaskDTO.ID)
                .MustAsync(_taskRepository.IsTaskExists).WithMessage("Task not found");

            RuleFor(request => request.UpdateTaskDTO.Title)
                .NotNull().WithMessage("Task title cannot be null")
                .NotEmpty().WithMessage("Task title cannot be empty string")
                .MaximumLength(100).WithMessage("Task title length should be less than 100 character");

            RuleFor(request => request.UpdateTaskDTO.Note)
                .MaximumLength(300).WithMessage("Task title length should be less than 300 character");

            RuleFor(request => request.UpdateTaskDTO.DueDate)
                .GreaterThan(DateTime.UtcNow.AddMinutes(1)).WithMessage("Task due date is not valid");
        }

    }
}

using FluentValidation;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskValidator()
        {
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

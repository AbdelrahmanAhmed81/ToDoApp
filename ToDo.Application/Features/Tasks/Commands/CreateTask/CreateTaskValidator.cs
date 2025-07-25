﻿using FluentValidation;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public CreateTaskValidator(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;

            RuleFor(request => request.RequestSenderUserId)
                .MustAsync(_userRepository.IsUserExistsAsync).WithMessage("User not found");

            RuleFor(request => request.CreateTaskDTO.Title)
                .NotNull().WithMessage("Task title cannot be null")
                .NotEmpty().WithMessage("Task title cannot be empty string")
                .MaximumLength(100).WithMessage("Task title length should be less than 100 character")
                .MustAsync(IsTitleUnique).WithMessage("User already has task with the same title, Title should be unique");

            RuleFor(request => request.CreateTaskDTO.Note)
                .MaximumLength(300).WithMessage("Task title length should be less than 300 character");

            RuleFor(request => request.CreateTaskDTO.DueDate)
                .GreaterThan(DateTime.UtcNow.AddMinutes(1)).WithMessage("Task due date is not valid");
        }

        private async Task<bool> IsTitleUnique(CreateTaskRequest request, string title, CancellationToken cancellationToken)
        {
            var userTasks = await _taskRepository.GetTasksByUserIdAsync(request.RequestSenderUserId);
            if (userTasks == null || !userTasks.Any())
            { return true; }

            if (userTasks.Any(t => t.Title == title))
            { return false; }

            return true;
        }
    }
}

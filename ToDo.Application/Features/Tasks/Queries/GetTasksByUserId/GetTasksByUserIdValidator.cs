using FluentValidation;
using ToDo.Application.Contracts.Repositories;

namespace ToDo.Application.Features.Tasks.Queries.GetTasksByUserId
{
    public class GetTasksByUserIdValidator : AbstractValidator<GetTasksByUserIdRequest>
    {
        private readonly IUserRepository _userRepository;

        public GetTasksByUserIdValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(request => request.UserId)
                .MustAsync(_userRepository.IsUserExistsAsync).WithMessage("User not found");
        }

    }
}

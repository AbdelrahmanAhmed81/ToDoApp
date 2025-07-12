using ToDo.Domain.Entities.Identity;

namespace ToDo.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid id);
    }
}

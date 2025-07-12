using Microsoft.AspNetCore.Identity;
using ToDo.Application.Contracts.Repositories;
using ToDo.Domain.Entities.Identity;

namespace ToDo.IdentityPresistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> GetUserAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }
    }
}

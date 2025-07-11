using Microsoft.EntityFrameworkCore;
using ToDo.Application.Contracts.Repositories;
using ToDo.Presistance.Contexts;


namespace ToDo.Presistance.Repositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByUserIdAsync(Guid userId)
        {
            return await _context.Tasks.AsNoTracking().Where(t => t.UserId == userId).ToListAsync();
        }
    }
}

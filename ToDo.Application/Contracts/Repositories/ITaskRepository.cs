

namespace ToDo.Application.Contracts.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTasksByUserIdAsync(Guid userId);
    }
}

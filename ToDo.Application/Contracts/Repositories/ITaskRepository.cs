using TaskEntity = ToDo.Domain.Entities.Task;

namespace ToDo.Application.Contracts.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
    }
}

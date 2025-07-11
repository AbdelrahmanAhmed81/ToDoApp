using ToDo.Application.Contracts.Repositories;
using ToDo.Presistance.Contexts;
using TaskEntity = ToDo.Domain.Entities.Task;

namespace ToDo.Presistance.Repositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

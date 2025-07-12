using ToDo.Domain.Enums;

namespace ToDo.Application.DTOs
{
    public class UpdateTaskDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
        public TaskPriority Priority { get; set; }
    }
}

using ToDo.Domain.Enums;

namespace ToDo.Application.DTOs
{
    public class CreateTaskDTO
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Note { get; set; }
        public TaskPriority Priority { get; set; }
    }
}

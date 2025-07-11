using ToDo.Domain.Common;
using ToDo.Domain.Entities.Identity;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities
{
    internal class Task : BaseEntityIdentified
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
        public TaskPriority Priority { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}

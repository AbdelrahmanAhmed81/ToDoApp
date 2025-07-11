using ToDo.Domain.Contracts;

namespace ToDo.Domain.Common
{
    public abstract class BaseEntity : IAuditableEntity, ISoftDeletableEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}

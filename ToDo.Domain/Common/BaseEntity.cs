using ToDo.Domain.Contracts;

namespace ToDo.Domain.Common
{
    internal abstract class BaseEntity: IBaseEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

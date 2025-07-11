using Microsoft.AspNetCore.Identity;
using ToDo.Domain.Contracts;

namespace ToDo.Domain.Entities.Identity
{
    internal class User : IdentityUser<Guid>, IBaseEntity
    {
        public DateTime CreateionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using ToDo.Domain.Contracts;

namespace ToDo.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>, IAuditableEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

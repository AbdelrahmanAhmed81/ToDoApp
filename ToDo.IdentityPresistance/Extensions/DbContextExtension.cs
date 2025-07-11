using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Identity;

namespace ToDo.IdentityPresistance.Extensions
{
    public static class DbContextExtension
    {
        public static void ModifyTrackerEntriesForAuditing(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<User>()
                .Where(q =>
                            q.State == EntityState.Added ||
                            q.State == EntityState.Modified))
            {
                entry.Entity.LastModificationDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreationDate = DateTime.UtcNow;
                }
            }
        }
    }
}

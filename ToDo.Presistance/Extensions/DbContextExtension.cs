using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Common;

namespace ToDo.Presistance.Extensions
{
    public static class DbContextExtension
    {
        public static void ModifyTrackerEntriesForAuditing(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>()
                .Where(q =>
                            q.State == EntityState.Added ||
                            q.State == EntityState.Modified ||
                            q.State == EntityState.Deleted))
            {
                entry.Entity.LastModificationDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreationDate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.DeletionDate = DateTime.UtcNow;
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}

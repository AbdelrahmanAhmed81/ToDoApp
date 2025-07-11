using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Common;
using ToDo.Presistance.EntitesConfigurations;
using ToDo.Presistance.Extensions;
using TaskEntity = ToDo.Domain.Entities.Task;

namespace ToDo.Presistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyGlobalSoftDeletedFilteration();
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.HasDefaultSchema("Application");
        }

        public override int SaveChanges()
        {
            this.ModifyTrackerEntriesForAuditing();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ModifyTrackerEntriesForAuditing();
            return base.SaveChangesAsync(cancellationToken);
        }

        override 

        public virtual DbSet<TaskEntity> Tasks { get; set; }
    }
}

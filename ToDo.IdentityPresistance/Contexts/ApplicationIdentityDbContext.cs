using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Identity;
using ToDo.IdentityPresistance.EntitesConfigurations;
using ToDo.IdentityPresistance.Extensions;
namespace ToDo.IdentityPresistance.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User , IdentityRole<Guid> , Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.HasDefaultSchema("Identity");            
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
    }
}

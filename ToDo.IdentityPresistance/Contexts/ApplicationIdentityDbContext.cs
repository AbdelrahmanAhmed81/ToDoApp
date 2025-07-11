using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Identity;
using ToDo.IdentityPresistance.EntitesConfigurations;
namespace ToDo.IdentityPresistance.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User , IdentityRole<Guid> , Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}

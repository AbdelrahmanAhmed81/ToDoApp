using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Identity;
namespace ToDo.IdentityPresistance.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User , IdentityRole<Guid> , Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            :base(options)
        {
        }


    }
}

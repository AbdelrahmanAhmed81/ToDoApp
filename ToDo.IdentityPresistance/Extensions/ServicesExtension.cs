using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Entities.Identity;
using ToDo.IdentityPresistance.Contexts;

namespace ToDo.IdentityPresistance.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterIdentityPresistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSqlServer<ApplicationIdentityDbContext>(configuration.GetConnectionString("ApplicationIdentityDbContext"));
           
            services
                .AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}

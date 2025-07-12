using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Contracts.Repositories;
using ToDo.Domain.Entities.Identity;
using ToDo.IdentityPresistance.Contexts;
using ToDo.IdentityPresistance.Repositories;

namespace ToDo.IdentityPresistance.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterIdentityPresistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSqlServer<ApplicationIdentityDbContext>(configuration.GetConnectionString("ApplicationIdentityDbContext"), options =>
                {
                    options.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName);
                });

            services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddDataProtection();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

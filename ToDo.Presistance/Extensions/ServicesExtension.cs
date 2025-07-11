using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Contracts.Repositories;
using ToDo.Presistance.Contexts;
using ToDo.Presistance.Repositories;

namespace ToDo.Presistance.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterPresistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSqlServer<ApplicationDbContext>(configuration.GetConnectionString("ApplicationDbContext"), options =>
                {
                    options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });

            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}

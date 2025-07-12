using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Features.Tasks.Commands.UpdateTask;
using ToDo.Application.Features.Tasks.Queries.GetTasksByUserId;

namespace ToDo.Application.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(options =>
            {
                options.AddMaps(Assembly.GetExecutingAssembly());
            });

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                options.Lifetime = ServiceLifetime.Scoped;
            });

            services.AddScoped<CreateTaskValidator>();
            services.AddScoped<UpdateTaskValidator>();
            services.AddScoped<GetTasksByUserIdValidator>();
        }
    }
}

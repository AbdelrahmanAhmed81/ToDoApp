using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Features.Tasks.Commands.UpdateTask;
using ToDo.Application.Features.Tasks.Queries.GetTasksByUserId;

namespace ToDo.Application.Features.Tasks
{
    public static class TasksFeatureServicesExtension
    {
        public static void RegisterTasksFeatureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CreateTaskValidator>();
            services.AddScoped<UpdateTaskValidator>();
            services.AddScoped<GetTasksByUserIdValidator>();
        }
    }
}

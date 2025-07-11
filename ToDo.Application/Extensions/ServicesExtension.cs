using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
        }
    }
}

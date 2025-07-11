using ToDo.Presistance.Extensions;
using ToDo.IdentityPresistance.Extensions;
using ToDo.Application.Extensions;


namespace ToDoApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.RegisterApplicationServices(builder.Configuration);
            builder.Services.RegisterPresistanceServices(builder.Configuration);
            builder.Services.RegisterIdentityPresistanceServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

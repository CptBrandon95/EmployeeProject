
using EmployeeProject.Business.MappingRegister;
using EmployeeProject.Common.Interface;
using EmployeeProject.Common.Model;
using EmployeeProject.Infrastructure.DbContext;
using EmployeeProject.Infrastructure.GenericRepos;

namespace EmployeeProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Injecting our db context
            DIConfiguration.RegisterServices(builder.Services);
            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            /*
             * Ensures that our database is created
             */

            using(var scope=app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
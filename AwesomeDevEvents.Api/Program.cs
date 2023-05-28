
using AwesomeDevEvents.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddDbContext<DevEventsDbContext>(use => use.UseInMemoryDatabase("DevEventDB"));
            var connectionString = builder.Configuration.GetConnectionString("Database");
            builder.Services.AddDbContext<DevEventsDbContext>((context) => context.UseSqlServer(connectionString)
            );

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
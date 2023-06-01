
using csharp_ef_workshop.api.Data;
using csharp_ef_workshop.api.Endpoint;
using csharp_ef_workshop.api.Repository;

namespace csharp_ef_workshop.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
            builder.Services.AddDbContext<PeopleContext>();
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

            app.ConfigurePersonApi();

            app.Seed();

            app.MapControllers();

            app.Run();
        }
    }
}
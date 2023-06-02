using csharp_ef_workshop.api.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace csharp_ef_workshop.api.Data
{
    public class PeopleContext : DbContext 
    {
        private static string GetConnectionString()
        {
            string jsonSettings = File.ReadAllText("appsettings.json");
            JObject configuration = JObject.Parse(jsonSettings);
            return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            //optionsBuilder.UseInMemoryDatabase(databaseName: "PeopleDatabase");
            optionsBuilder.UseNpgsql(GetConnectionString());

        }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Course> Courses { get; set; }
    
    }
}

using csharp_ef_workshop.api.Model;
using Microsoft.EntityFrameworkCore;

namespace csharp_ef_workshop.api.Data
{
    public class PeopleContext : DbContext
    {
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseInMemoryDatabase(databaseName: "PeopleDatabase");

        }
        
        public DbSet<Person> People { get; set; }
    
    }
}

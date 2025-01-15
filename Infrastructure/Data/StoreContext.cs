using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //{1.1} DbSet<T> - represents a table or collection in the database
    //{1.2} DbSet<T> - Each DbSet<T> corresponds to an entity type in your application
    //{2.1} Database Connection - Handles connection to database using connection string
    //{2.2} Database Connection - Configure connection string using method OnConfiguring()
    //{3.1} Model Configuration - Defines how your C# classes map to database tables
    //{3.2} Model Configuration - Defines using FLUENT API in the OnModelCreating() method
    // There are other classes as well but the above three are fundamental
    public class StoreContext : DbContext
    {
        public StoreContext( DbContextOptions<StoreContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}

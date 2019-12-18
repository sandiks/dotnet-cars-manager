using CarsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsManager.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Car>().ToTable("Car");
        }
    }
}
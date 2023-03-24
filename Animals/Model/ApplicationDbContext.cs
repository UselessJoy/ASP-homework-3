using Microsoft.EntityFrameworkCore;
using Animals.Model.Entity;

namespace Animals.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AnimalsTable> AnimalsExamples { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Feeding> Feedings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().
                SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
                AddJsonFile("appsettings.json").
                Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}

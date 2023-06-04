using ConsoleTestAppWeather.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTestAppWeather.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Weather> weathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=weathers.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

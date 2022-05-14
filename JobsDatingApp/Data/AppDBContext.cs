using JobsDatingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Persistance
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        //public DbSet<Person> Persons { get; set; } = null!;
        //public DbSet<Address> Addresses { get; set; } = null!;
        public string dbPath = "JobsDatingAppDB.db";
        public AppDBContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasIndex(a => a.name).IsUnique();
        }
    }
}

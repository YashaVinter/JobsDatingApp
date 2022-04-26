using Microsoft.EntityFrameworkCore;
using JobsDatingApp.Models;

namespace JobsDatingApp.Models
{
    /// <summary>
    ///  TODO rename
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        //public DbSet<Person> Persons { get; set; } = null!;
        //public DbSet<Address> Addresses { get; set; } = null!;
        public string dbPath = @"C:\Users\User\source\repos\EntityFrameworkApp\EntityFrameworkApp\TelegramBotDB.db";
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");// TelegramBotDB / TelegramBotDB
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasIndex(a => a.name).IsUnique();
        }
    }
    public class Test 
    {
        public void Test1() 
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    //recreated Database
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();
            //    // adding all persons in DbData
            //    var persons = new List<Person>
            //    {
            //        DbData.Yan, DbData.Polina, DbData.Artem
            //    };
            //    db.Persons.AddRange(persons);
            //    db.SaveChanges();
            //}
        }
    }
}
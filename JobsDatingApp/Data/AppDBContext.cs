using JobsDatingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data
{
    public class AppDBContext : DbContext
    {
        private readonly string _connection;
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<LastViewedVacancy>().HasKey(k => new { k.UserId, k.VacancyId });
            //modelBuilder.Entity<LikeInfo>().HasKey(k => new {k.UserId,k.VacancyId });
            //modelBuilder.Entity<Company>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Company>().HasData(seedData.Companies);
            //modelBuilder.Entity<Vacancy>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Vacancy>().HasData(seedData.Vacancies);
            //modelBuilder.Entity<User>().HasData(seedData.Users);
        }
    }
}
    
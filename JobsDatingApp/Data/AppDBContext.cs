using JobsDatingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Vacancy> Vacancies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<LastViewedVacancy>().HasKey(k => new { k.UserId, k.VacancyId });
            modelBuilder.Entity<Company>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Vacancy>().Property(p => p.Id).ValueGeneratedNever();
        }
    }
}
    
using JobsDatingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {    
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<LikeInfo> UserVacancies { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LastViewedVacancy>().HasKey(k => new { k.UserId, k.VacancyId });
            //modelBuilder.Entity<LikeInfo>().HasKey(k => new {k.UserId,k.VacancyId });

            modelBuilder.Entity<Company>().HasData(DBObjects.Companies);
            modelBuilder.Entity<Vacancy>().HasData(DBObjects.Vacancies);
            modelBuilder.Entity<User>().HasData(DBObjects.Users);

            //modelBuilder
            //    .Entity<User>()
            //    .HasMany(u => u.Vacancies)
            //    .WithMany(v => v.Users)
            //    .UsingEntity<LikeInfo>(
            //        li => li
            //        .HasOne(li => li.User)
            //        .WithMany(u => u.LikeInfoes)
            //        .HasForeignKey(li => li.UserId),
            //        li => li
            //        .HasOne(li => li.Vacancy)
            //        .WithMany(li => li.LikeInfoes)
            //        .HasForeignKey(li => li.VacancyId)
            //        );
        }
    }
}
    
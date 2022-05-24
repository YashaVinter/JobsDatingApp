using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.SeedData;
using JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            string hhRequestUri = "https://api.hh.ru/vacancies?text=developer&area=113";
            var seedData = new DBSeed(new HHDBSeed(hhRequestUri));
            
            modelBuilder.Entity<LastViewedVacancy>().HasKey(k => new { k.UserId, k.VacancyId });
            //modelBuilder.Entity<LikeInfo>().HasKey(k => new {k.UserId,k.VacancyId });
            //modelBuilder.Entity<Company>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Company>().HasData(seedData.Companies);
            //modelBuilder.Entity<Vacancy>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Vacancy>().HasData(seedData.Vacancies);
            modelBuilder.Entity<User>().HasData(seedData.Users);            
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
    
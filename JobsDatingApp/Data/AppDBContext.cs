using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.SeedData;
using JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data
{
    public class AppDBContext : DbContext
    {
        private readonly string _connection;
        //public AppDBContext(string connection = "")
        //{
        //    _connection = connection;
        //    //Database.EnsureCreated();
        //}
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<LikeInfo> UserVacancies { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connection);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<LastViewedVacancy>().HasKey(k => new { k.UserId, k.VacancyId });
            //modelBuilder.Entity<LikeInfo>().HasKey(k => new {k.UserId,k.VacancyId });
            //modelBuilder.Entity<Company>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Company>().HasData(seedData.Companies);
            //modelBuilder.Entity<Vacancy>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Vacancy>().HasData(seedData.Vacancies);
            //modelBuilder.Entity<User>().HasData(seedData.Users);            
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
    
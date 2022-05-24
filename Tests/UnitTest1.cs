using JobsDatingApp.Data;
using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.SeedData;
using JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetCompanies()
        {
            int count = 17;
            string request = "https://api.hh.ru/vacancies?text=developer&area=113";
            var seed = new DBSeed(new HHDBSeed(request));
            var ñompanies = seed.Companies;
            //var distCompanies = seed.GetCompanies().ToHashSet();
            //var distinctCompaniesId = new HashSet<int>(ñompanies.Select(c => c.Id));
            Assert.Equal(count, ñompanies.Count());
        }
        [Fact]
        public void TestGetVacancies()
        {
            int count = 20;
            string request = "https://api.hh.ru/vacancies?text=developer&area=113";
            var seed = new HHDBSeed(request);
            int resCount = seed.GetVacancies().Count();
            Assert.Equal(count, resCount);
        }
        [Fact]
        public void TestGetUsers()
        {
            int count = 1;
            string request = "https://api.hh.ru/vacancies?text=developer&area=113";
            var seed = new HHDBSeed(request);
            int resCount = seed.GetUsers().Count();
            Assert.Equal(count, resCount);
        }
        [Fact]
        public void TestDB()
        {
            string connection = "Server=(localdb)\\MSSQLLocalDB;Database=JobsDatingAppDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer("");
            var v = new DbContextOptions<AppDBContext>();
            
            using (var db = new AppDBContext(null))
            {
                //var v = db.Vacancies.ToArray();
                db.SaveChanges();
            }
            Assert.True(true);
        }
        
    }
}
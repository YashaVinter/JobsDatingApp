using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API;
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
            int count = 20;
            string request = "https://api.hh.ru/vacancies?text=developer&area=113";
            var seed = new HHDBSeed(request);
            int resCount = seed.GetCompanies().Count();
            Assert.Equal(count, resCount);
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
    }
}
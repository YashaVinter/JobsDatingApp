using JobsDatingApp.Models;
using System.Security.Claims;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // testing Vacancy1
            //create user with cookie
            Claim claim = new Claim(CookiesLiterals.LastViewedVacancyId, "");
            ClaimsIdentity identity = new ClaimsIdentity(new Claim[] { claim});
            ClaimsPrincipal mockUser = new ClaimsPrincipal(identity);
            //testing
        }
    }
}
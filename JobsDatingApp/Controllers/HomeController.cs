using JobsDatingApp.Models;
using JobsDatingApp.Models.Storage;
using JobsDatingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using JobsDatingApp.Filters;

namespace JobsDatingApp.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TestViewModel testViewModel;

        public HomeController(ILogger<HomeController> logger, TestViewModel testViewModel)
        {
            _logger = logger;
            this.testViewModel = testViewModel;
        }
        public async Task<IActionResult> Index()
        {
            //var v2 = new Guid(Guid.NewGuid().ToString());
            //v2 = Guid.NewGuid();

            //var v3 = new Claim[] { new("","") };

            //var user = this.HttpContext.User.Identity;
            //var v1 = this.HttpContext.Request.Cookies;
            ////await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //var claimsIdentity = new ClaimsIdentity(new List<Claim> { new(ClaimTypes.Name, "user1") },
            //    CookieAuthenticationDefaults.AuthenticationScheme);
            //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            //await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            ////var v = this.HttpContext.User.Claims;
            ////var v = this.HttpContext.Request.Cookies.Append(new("", ""));
            ////var v1 = this.HttpContext.Session.Id;
            return View() ;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Find()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View(testViewModel);
        }
        //public IActionResult Test2()
        //{
        //    return View(new TestViewModel(new MockDataBase().Vacancies.First()));
        //}
        //public IActionResult Test1(TestViewModel testViewModel)
        //{
        //    return View(testViewModel);
        //}
        public IActionResult Like() 
        {
            var v1 = this.HttpContext.Session.Id;
            testViewModel.NextVacancy();
            return View(testViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
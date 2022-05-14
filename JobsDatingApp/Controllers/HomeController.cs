using JobsDatingApp.Models;
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
        private VacancyViewModel vacancyViewModel;

        public HomeController(ILogger<HomeController> logger, VacancyViewModel testViewModel)
        {
            _logger = logger;
            this.vacancyViewModel = null!;

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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Find()
        {
            return View();
        }
        public IActionResult Vacancy()
        {
            return View(vacancyViewModel);
        }
        public async Task<IActionResult> Vacancy1([FromServices] MockDataBase dataBase)
        {
            var user = this.HttpContext.User;
            // ---new---
            var vacancyId = ParseUserVacancyId(user);
            var model = new VacancyViewModel(dataBase, vacancyId);
            await WriteUserCookie(this.HttpContext, model.Vacancy1.Id.ToString());
            return View(model);
        }
        /*
                     ////var model = new VacancyViewModel(dataBase, user);
            //var userLastViewedVacancyId = user.FindFirst(CookiesLiterals.LastViewedVacancyId);
            //if (user.Identity is ClaimsIdentity claimsIdentity)
            //{
                
            //    //var v = dataBase.Vacancies.FirstOrDefault(v => v.Id == Conv userLastViewedVacancyId.Value)
            //    //var c = new Claim(CookiesLiterals.LastViewedVacancyId,)
            //    //claimsIdentity.
            //}
            ////userLastViewedVacancyId = model.Vacancy1.Id;
            ////
            IsUserLastViewedVacancyValid(user);
                var model = new VacancyViewModel(dataBase, this.HttpContext.User);
            await WriteUserCookie(this.HttpContext, model.Vacancy1.Id.ToString());
            //return View(model);
            return View(model);
            //return RedirectToAction("Error.cshtml");
         */
        private void WriteUserViewedVacany(MockDataBase dataBase, System.Security.Claims.ClaimsPrincipal user) 
        {
            try{
                Claim userLastViewedVacancy = user.FindFirst(CookiesLiterals.LastViewedVacancyId)!;
                var userLastViewedVacancyId = Convert.ToInt32(userLastViewedVacancy.Value);
            }
            catch (Exception){
                _logger.Log(LogLevel.Warning, "Problem with user Cookie: \"Claim LastViewedVacancyId\"");
            }

        }
        private bool HasUserLastViewedVacancy(MockDataBase dataBase, System.Security.Claims.ClaimsPrincipal user) 
        {
            Claim userLastViewedVacancy = user.FindFirst(CookiesLiterals.LastViewedVacancyId)!;
            if (userLastViewedVacancy is null){
                _logger.Log(LogLevel.Warning, @"User's cookie is null");
                return false;
            }
            int userLastViewedVacancyId;
            if (!int.TryParse(userLastViewedVacancy.Value, out userLastViewedVacancyId)){
                _logger.Log(LogLevel.Warning, @"User's cookie is not valid");
                return false;
            }
            if (!dataBase.Vacancies.Any(v => v.Id == userLastViewedVacancyId)){
                _logger.Log(LogLevel.Warning, @"User's cookie not found in db");
                return false;
            }
            return true;
        }
        private bool IsUserLastViewedVacancyValid(System.Security.Claims.ClaimsPrincipal user) 
        {
            Claim userLastViewedVacancy = user.FindFirst(CookiesLiterals.LastViewedVacancyId)!;
            if (userLastViewedVacancy is null)
            {
                _logger.Log(LogLevel.Warning, @"User's cookie is null");
                return false;
            }
            int userLastViewedVacancyId;
            if (!int.TryParse(userLastViewedVacancy.Value, out userLastViewedVacancyId))
            {
                _logger.Log(LogLevel.Warning, @"User's cookie is not valid");
                return false;
            }
            return true;
        }
        private int? ParseUserVacancyId(System.Security.Claims.ClaimsPrincipal user) 
        {
            int vacancyId;
            if (int.TryParse(user.FindFirst(CookiesLiterals.LastViewedVacancyId)?.Value, out vacancyId)){
                return vacancyId;
            }
            _logger.Log(LogLevel.Warning, @"User's cookie is not valid");
            return null;
        }
        private async Task WriteUserCookie(HttpContext context,string vacancyId)
        {
            if (context.User.Identity is ClaimsIdentity claimsIdentity)
            {
                //
                if (claimsIdentity.FindFirst(CookiesLiterals.LastViewedVacancyId) is Claim claim) {
                    claimsIdentity.RemoveClaim(claim);
                }
                //
                // add check to exist claim
                claimsIdentity.AddClaim(new Claim(CookiesLiterals.LastViewedVacancyId, vacancyId));
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await context.SignInAsync(claimsPrincipal);
            }
        }
        public IActionResult Test1() 
        {
            return View(vacancyViewModel);
        }
        //public IActionResult Test2()
        //{
        //    return View(new TestViewModel(new MockDataBase().Vacancies.First()));
        //}
        //public IActionResult Test1(TestViewModel testViewModel)
        //{
        //    return View(testViewModel);
        //}
        public IActionResult Back()
        {
            vacancyViewModel.PreviousVacancy();
            return View(vacancyViewModel);
        }
        public IActionResult Like() 
        {
            //var v1 = this.HttpContext.Session.Id;
            vacancyViewModel.NextVacancy();
            return View(vacancyViewModel);
        }
        public async Task<IActionResult> Like1([FromServices] MockDataBase dataBase)
        {
            IsUserLastViewedVacancyValid(this.HttpContext.User);
            var model = new VacancyViewModel(dataBase, this.HttpContext.User);
            model.NextVacancy1();
            await WriteUserCookie(this.HttpContext, model.Vacancy1.Id.ToString());
            return View(model);
        }
        public IActionResult DisLike([FromServices] MockDataBase dataBase)
        {
            var vacancyViewModel = new VacancyViewModel(dataBase, this.HttpContext.User);
            if (vacancyViewModel.NextVacancy1()) { 
                //dataBase.Users.fi
            }
            return View(vacancyViewModel);
        }

        public IActionResult VacancyInfo()
        {
            return View(vacancyViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
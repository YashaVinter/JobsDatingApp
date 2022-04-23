using JobsDatingApp.Models;
using JobsDatingApp.Models.Storage;
using JobsDatingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace JobsDatingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TestViewModel testViewModel;

        public HomeController(ILogger<HomeController> logger, TestViewModel testViewModel)
        {
            _logger = logger;
            this.testViewModel = testViewModel;
        }

        public IActionResult Index()
        {
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
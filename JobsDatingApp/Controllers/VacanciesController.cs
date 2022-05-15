using JobsDatingApp.Data.interfaces;
using JobsDatingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobsDatingApp.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly IVacanciesRepository vacanciesRepository;
        public VacanciesController(IVacanciesRepository vacanciesRepository)
        {
            this.vacanciesRepository = vacanciesRepository;
        }
        public IActionResult Index()
        {
            var model = new VacanciesIndexViewModel();
            return View(model);
        }
    }
}

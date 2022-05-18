using JobsDatingApp.Data.interfaces;
using JobsDatingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsDatingApp.Controllers
{
    public class TestController : Controller
    {
        private readonly ICompaniesRepository companiesRepository;
        private readonly IVacanciesRepository vacanciesRepository;
        private readonly IUsersRepository usersRepository;
        public TestController(
            ICompaniesRepository companiesRepository,
            IVacanciesRepository vacanciesRepository,
            IUsersRepository usersRepository)
        {
            this.companiesRepository = companiesRepository;
            this.vacanciesRepository = vacanciesRepository;
            this.usersRepository = usersRepository;
        }
        //[Authorize] // UseAuthentication
        public IActionResult Index()
        {
            // add last view vac to user
            var v1 = vacanciesRepository.VacancyById(1);
            var v2 = vacanciesRepository.VacancyById(2);

            var users = usersRepository.Users(true);
            var usersList = users.ToList();
            var user = usersList.FirstOrDefault();
            user = usersRepository.UserById(user.Id);
            user.LastViewedVacancy = new() { Vacancy = v1};
            user.LikedVacancies = new() { v1, v2 };
            usersRepository.UpdateUser(user);

            user = usersRepository.UserById(user.Id);
            return Redirect("/");
        }
    }
}

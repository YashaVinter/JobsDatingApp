using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using JobsDatingApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobsDatingApp.Controllers
{
    [Authorize]
    public class VacanciesController : Controller
    {
        private readonly ILogger<VacanciesController> _logger;
        private readonly IVacanciesRepository _vacanciesRepository;
        private readonly IUsersRepository _usersRepository;
        private User _currentUser = null!;
        private User CurrentUser
        {
            get
            {
				if (_currentUser is null)
				{
                    _currentUser = FindCurrentUser();
                }
                return _currentUser;
            }
            set 
            {
                _currentUser = value;
            }
        }
		public VacanciesController(
            ILogger<VacanciesController> logger,
            IVacanciesRepository vacanciesRepository,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _vacanciesRepository = vacanciesRepository;
            _usersRepository = usersRepository;
        }
        public async Task<IActionResult> Index()
        {
            Vacancy? vacancy;
            // find LastViewedVacancy in cookie
            if (TryParseUserCookieVacancyId(out int vacancyId))
			{
                vacancy = _vacanciesRepository.VacancyById(vacancyId);
                return View(new VacanciesIndexViewModel { Vacancy = vacancy });
            }
            // find LastViewedVacancy in DataBase
            vacancy = CurrentUser?.LastViewedVacancy?.Vacancy;
            if (vacancy is not null)
			{
                return View(new VacanciesIndexViewModel { Vacancy = vacancy } );
            }
            //LastViewedVacancy not found case
            vacancy = _vacanciesRepository.FirstVacancy();
            CurrentUser!.LastViewedVacancy = new LastViewedVacancy()
            {
                User = CurrentUser,
                Vacancy = vacancy
            };
            _usersRepository.UpdateUser(CurrentUser);
            await WriteUserCookieAsync(vacancy.Id.ToString());
            return View(new VacanciesIndexViewModel { Vacancy = vacancy });
        }
        public async Task<IActionResult> Like() 
        {
            Vacancy? vacancy = null;
            // find LastViewedVacancy in cookie
            if (TryParseUserCookieVacancyId(out int vacancyId))
            {
                vacancy = _vacanciesRepository.VacancyById(vacancyId);
            }
            // find LastViewedVacancy in DataBase
            vacancy ??= CurrentUser?.LastViewedVacancy?.Vacancy;
            // case find LastViewedVacancy in DataBase is null
            vacancy ??= _vacanciesRepository.FirstVacancy();
            // adding like vacancy
            var likedVacancies = CurrentUser?.LikedVacancies;
            if (likedVacancies is null || likedVacancies.Count == 0)
            {
                likedVacancies = new HashSet<Vacancy>();
            }
            likedVacancies.Add(vacancy);
            //write next vacancy
            var  nextVacancy = _vacanciesRepository.NextVacancy(vacancy.Id);
            CurrentUser!.LastViewedVacancy = new LastViewedVacancy 
            { 
                User = CurrentUser, 
                Vacancy = nextVacancy 
            };
            _usersRepository.UpdateUser(CurrentUser);
            await WriteUserCookieAsync(nextVacancy.Id.ToString());
            return View(nameof(Index),new VacanciesIndexViewModel { Vacancy = nextVacancy });
        }
        private bool TryParseUserCookieVacancyId(out int vacancyId)
        {
            bool parse = int.TryParse(User.FindFirstValue(CookiesLiterals.LastViewedVacancyId), out vacancyId);
            if (!parse)
                _logger.LogWarning("User's cookie is not valid");
            return parse;
        }
        private User FindCurrentUser() 
        {
            var guid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _usersRepository.UserById(guid)!;
        }
        private async Task WriteUserCookieAsync(string vacancyId)
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			if (claimsIdentity is null)
			{
                _logger.LogWarning("context.User.Identity dont upcasting");
                return;
			}
			if (claimsIdentity.FindFirst(CookiesLiterals.LastViewedVacancyId) is Claim claim)
			{
				if (claim.Value.Equals(vacancyId))
				{
                    return;
				}
                claimsIdentity.RemoveClaim(claim);
            }
			claimsIdentity.AddClaim(new Claim(CookiesLiterals.LastViewedVacancyId, vacancyId));
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			await HttpContext.SignInAsync(claimsPrincipal);
        }
        //private async Task<IActionResult> Test() 
        //{
        //    var t1 = AddLikeVacancyToUserDb(null);
        //    var t2 = AddLastViewedVacancyToUserDb(null);
        //    var t3 =  Task.Run(() => View());
        //    await Task.WhenAll(t1,t2,t3);
        //    return t3.Result;
        //}
    }
}

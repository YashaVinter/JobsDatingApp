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
        private readonly Lazy<User> _currentUser;
		public VacanciesController(
            ILogger<VacanciesController> logger,
            IVacanciesRepository vacanciesRepository,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _vacanciesRepository = vacanciesRepository;
            _usersRepository = usersRepository;
            _currentUser = new Lazy<User>(() => FindCurrentUser());
        }
        public async Task<IActionResult> Index()
        {
            //TODO change to try catch
            // Validation of vacancy
            Vacancy? vacancy = TryGetUserVacancyFromCookie();
            if (vacancy is not null)
                return View(new VacanciesIndexViewModel { Vacancy = vacancy });
            vacancy ??= TryGetUserVacancyFromDb();
            if (vacancy is not null)
                return View(new VacanciesIndexViewModel { Vacancy = vacancy });
            vacancy ??= _vacanciesRepository.FirstVacancy();
            // Update user data
            _currentUser.Value!.LastViewedVacancy = new LastViewedVacancy()
            {
                User = _currentUser.Value,
                Vacancy = vacancy
            };
            _usersRepository.UpdateUser(_currentUser.Value);
            await WriteViewedVacancyIdToUserCookieAsync(vacancy.Id.ToString());
            return View(new VacanciesIndexViewModel { Vacancy = vacancy });
        }
        public async Task<IActionResult> Back()
        {
            // Validation of vacancy
            Vacancy? vacancy = TryGetUserVacancyFromCookie();
            vacancy ??= TryGetUserVacancyFromDb();
            vacancy ??= _vacanciesRepository.FirstVacancy();
            // Update user data
            var prevVacancy = _vacanciesRepository.PrevVacancy(vacancy.Id);
            _currentUser.Value!.LastViewedVacancy = new LastViewedVacancy
            {
                User = _currentUser.Value,
                Vacancy = prevVacancy
            };
            _usersRepository.UpdateUser(_currentUser.Value);
            await WriteViewedVacancyIdToUserCookieAsync(prevVacancy.Id.ToString());
            return View(nameof(Index), new VacanciesIndexViewModel { Vacancy = prevVacancy });
        }
        public async Task<IActionResult> DisLike()
        {
            // Validation of vacancy
            Vacancy? vacancy = TryGetUserVacancyFromCookie();
            vacancy ??= TryGetUserVacancyFromDb();
            vacancy ??= _vacanciesRepository.FirstVacancy();
            // Update user data
            var nextVacancy = _vacanciesRepository.NextVacancy(vacancy.Id);
            _currentUser.Value!.LastViewedVacancy = new LastViewedVacancy
            {
                User = _currentUser.Value,
                Vacancy = nextVacancy
            };
            _usersRepository.UpdateUser(_currentUser.Value);
            await WriteViewedVacancyIdToUserCookieAsync(nextVacancy.Id.ToString());
            return View(nameof(Index), new VacanciesIndexViewModel { Vacancy = nextVacancy });
        }
        public async Task<IActionResult> Like()
        {
            // Validation of vacancy
            Vacancy? vacancy = TryGetUserVacancyFromCookie();
            vacancy ??= TryGetUserVacancyFromDb();
            vacancy ??= _vacanciesRepository.FirstVacancy();
            AddLikeVacancyToCurrentUser(vacancy);
            // Update user data
            var nextVacancy = _vacanciesRepository.NextVacancy(vacancy.Id);
            _currentUser.Value!.LastViewedVacancy = new LastViewedVacancy
            {
                User = _currentUser.Value,
                Vacancy = nextVacancy
            };
            _usersRepository.UpdateUser(_currentUser.Value);
            await WriteViewedVacancyIdToUserCookieAsync(nextVacancy.Id.ToString());
            return View(nameof(Index), new VacanciesIndexViewModel { Vacancy = nextVacancy });
        }
        public IActionResult VacancyInfo()
        {
            // Validation of vacancy
            Vacancy? vacancy = TryGetUserVacancyFromCookie();
            vacancy ??= TryGetUserVacancyFromDb();
            return View(new VacanciesIndexViewModel { Vacancy = vacancy });
        }
        private Vacancy? TryGetUserVacancyFromCookie() //TODO change to try catch
        {
            Vacancy? vacancy = null;
            if (TryParseUserCookieVacancyId(out int vacancyId))
			{
                vacancy = _vacanciesRepository.VacancyById(vacancyId);
			}
            return vacancy;
        }
        private bool TryParseUserCookieVacancyId(out int vacancyId)
        {
            bool parse = int.TryParse(User.FindFirstValue(CookiesLiterals.LastViewedVacancyId), out vacancyId);
            if (!parse)
                _logger.LogWarning("User's cookie is not valid");
            return parse;
        }
        private Vacancy? TryGetUserVacancyFromDb() //TODO change to try catch
        {
            return _currentUser!.Value?.LastViewedVacancy?.Vacancy;
        }
        private void AddLikeVacancyToCurrentUser(Vacancy vacancy)
        {
            var likedVacancies = _currentUser.Value.LikedVacancies;
            if (likedVacancies is null || likedVacancies.Count == 0)
            {
                likedVacancies = new HashSet<Vacancy>();
            }
            likedVacancies.Add(vacancy);
            _currentUser.Value!.LikedVacancies = likedVacancies;
        }
        private User FindCurrentUser() 
        {
            var guid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _usersRepository.UserById(guid)!;
        }
        private async Task WriteViewedVacancyIdToUserCookieAsync(string vacancyId)
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
			if (claimsIdentity is null)
			{
                _logger.LogWarning("Error HttpContext.User.Identity");
                return;
			}
			if (claimsIdentity.FindFirst(CookiesLiterals.LastViewedVacancyId) is Claim claim)
			{
                // Cookie already exist
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
    }
}

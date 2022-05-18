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
        //private Vacancy? _currentVacancy;
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
    //    private Vacancy CurrentVacancy 
    //    {
    //        get 
    //        {
				//if (_currentVacancy is null)
				//{
    //                _currentVacancy = FindUserVacancy() ?? _vacanciesRepository.FirstVacancy();
				//}
    //            return _currentVacancy;
    //        } 
    //        set 
    //        {
    //            _currentVacancy = value;
    //        }
    //    }

		public VacanciesController(
            ILogger<VacanciesController> logger,
            IVacanciesRepository vacanciesRepository,
            IUsersRepository usersRepository)
        {
            _logger = logger;
            _vacanciesRepository = vacanciesRepository;
            _usersRepository = usersRepository;
        }
        //public async Task<IActionResult> Index1() 
        //{
        //    Vacancy vacancy;
        //    if (TryParseUserVacancyId(out int vacancyId))
        //    {
        //        vacancy = _vacanciesRepository.VacancyById(vacancyId);
        //        AddLastViewedVacancyToUserDb(vacancy);
        //    }
        //    else
        //    {
        //        vacancy = _vacanciesRepository.FirstVacancy();
        //        await WriteUserCookieAsync(HttpContext, vacancy.Id.ToString());
        //    }
        //    var model = new VacanciesIndexViewModel { Vacancy = vacancy };
        //    return View(model);
        //}

        public async Task<IActionResult> Index()
        {
            //
            var vacancy = CurrentUser?.LastViewedVacancy?.Vacancy;
            if (vacancy is not null)
			{
                return View(new VacanciesIndexViewModel { Vacancy = vacancy } );
            }
            vacancy = _vacanciesRepository.FirstVacancy();
            CurrentUser!.LastViewedVacancy = new LastViewedVacancy()
            {
                User = CurrentUser,
                Vacancy = vacancy
            };
            _usersRepository.UpdateUser(CurrentUser);
            await WriteUserCookieAsync1(vacancy.Id.ToString());
            return View(new VacanciesIndexViewModel { Vacancy = vacancy });
        }
        //public async Task<IActionResult> Like1()
        //{
        //    var vacancyId = ParseUserVacancyId();
        //    if (vacancyId is null)
        //    {
        //        return Redirect(nameof(Index));
        //    }
        //    Vacancy vacancy = _vacanciesRepository.VacancyById(vacancyId.Value);
        //    vacancy = _vacanciesRepository.NextVacancy(vacancy.Id);
        //    var model = new VacanciesIndexViewModel { Vacancy = vacancy };
        //    AddLikeVacancyToUserDb(vacancy);
        //    await WriteUserCookieAsync(HttpContext, vacancy.Id.ToString());
        //    return View(nameof(Index), model);
        //}
        public async Task<IActionResult> Like() 
        {
            // determine vacancy
            //TODO change to cookie
            var vacancy = CurrentUser?.LastViewedVacancy?.Vacancy;
			if (vacancy is null)
			{
                vacancy = _vacanciesRepository.FirstVacancy(); // rewrite
			}
            // adding like vacancy
            var likedVacancies = CurrentUser?.LikedVacancies;
            if (likedVacancies is null || likedVacancies.Count == 0)
            {
                likedVacancies = new HashSet<Vacancy> { vacancy };
            }
            likedVacancies.Add(vacancy);
            //write next vacancy
            var  nextVacancy = _vacanciesRepository.NextVacancy(vacancy.Id);
            //CurrentUser!.LastViewedVacancy!.Vacancy = nextVacancy; dont work
            CurrentUser!.LastViewedVacancy = new LastViewedVacancy { User = CurrentUser, Vacancy = nextVacancy };

            _usersRepository.UpdateUser(CurrentUser);
            await WriteUserCookieAsync1(nextVacancy.Id.ToString()); // why?
            return View(nameof(Index),new VacanciesIndexViewModel { Vacancy = nextVacancy });
        }
        //public async Task<IActionResult> Like()
        //{
        //    CurrentVacancy = _vacanciesRepository.NextVacancy(CurrentVacancy.Id);
        //    AddLastViewedVacancyToUserDb(CurrentVacancy);
        //    AddLikeVacancyToUserDb(CurrentVacancy);
        //    await WriteUserCookieAsync1(CurrentVacancy.Id.ToString());
        //    var model = new VacanciesIndexViewModel { Vacancy = CurrentVacancy };
        //    return View(nameof(Index), model);
        //}
        private int? ParseUserVacancyId()
        {
            int vacancyId;
            if (int.TryParse(User.FindFirst(CookiesLiterals.LastViewedVacancyId)?.Value, out vacancyId))
            {
                return vacancyId;
            }
            _logger.Log(LogLevel.Warning, @"User's cookie is not valid");
            return null;
        }
        private bool TryParseUserVacancyId(out int vacancyId)
        {
            bool parse = int.TryParse(User.FindFirstValue(CookiesLiterals.LastViewedVacancyId), out vacancyId);
            if (!parse)
                _logger.LogWarning("User's cookie is not valid");
            return parse;
        }
        private void AddLikeVacancyToUserDb(Vacancy vacancy)
        {
            if (CurrentUser.LikedVacancies is null)
            {
                CurrentUser.LikedVacancies = new HashSet<Vacancy> { vacancy };
            }
            else
            {
                CurrentUser.LikedVacancies.Add(vacancy);
            }
            _usersRepository.UpdateUser(CurrentUser);
        }
        private void AddViewedVacancyToUserDb(Vacancy vacancy) 
        {
			//
			if (CurrentUser!.LastViewedVacancy!.Vacancy!.Equals(vacancy))
			{
                return;
			}
            //
            if (CurrentUser.LastViewedVacancy is null)
            {
                CurrentUser.LastViewedVacancy = new() { User = CurrentUser, Vacancy = vacancy };
            }
            else
            {
                CurrentUser.LastViewedVacancy.Vacancy = vacancy;
            }
            _usersRepository.UpdateUser(CurrentUser);
        }
        private User FindCurrentUser() 
        {
            var guid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _usersRepository.UserById(guid)!;
        }
        private Vacancy? FindUserVacancy() 
        {
            if (TryParseUserVacancyId(out int vacancyId))
            {
                return _vacanciesRepository.VacancyById(vacancyId);
            }
            return null;
        }
        private async Task WriteUserCookieAsync(HttpContext context, string vacancyId)
        {
            if (context.User.Identity is ClaimsIdentity claimsIdentity)
            {
                //
                if (claimsIdentity.FindFirst(CookiesLiterals.LastViewedVacancyId) is Claim claim)
                {
                    claimsIdentity.RemoveClaim(claim);
                }
                //
                // add check to exist claim
                claimsIdentity.AddClaim(new Claim(CookiesLiterals.LastViewedVacancyId, vacancyId));
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await context.SignInAsync(claimsPrincipal);
            }
        }
        private async Task WriteUserCookieAsync1(string vacancyId)
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

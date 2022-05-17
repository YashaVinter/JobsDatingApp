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
        public VacanciesController(
            ILogger<VacanciesController> logger,
            IVacanciesRepository vacanciesRepository,
            IUsersRepository usersRepository)
        {
            this._logger = logger;
            this._vacanciesRepository = vacanciesRepository;
            this._usersRepository = usersRepository;
        }
        public async Task<IActionResult> Index()
        {
            Vacancy vacancy;
            if (TryParseUserVacancyId(out int vacancyId))
            {
                vacancy = _vacanciesRepository.VacancyById(vacancyId);
            }
            else
            {
                vacancy = _vacanciesRepository.FirstVacancy();
                await WriteUserCookie(HttpContext, vacancy.Id.ToString());
            }
            var model = new VacanciesIndexViewModel { Vacancy = vacancy };
            return View(model);
        }
        public async Task<IActionResult> Like() 
        {
            //

            //
            var vacancyId = ParseUserVacancyId();
            if (vacancyId is null){
                return Redirect(nameof(Index));
            }
            Vacancy vacancy = _vacanciesRepository.VacancyById(vacancyId.Value);
            vacancy = _vacanciesRepository.NextVacancy(vacancy.Id);
            var model = new VacanciesIndexViewModel { Vacancy = vacancy };
            await AddLikeVacancyToUserDb(vacancy);
            await WriteUserCookie(HttpContext, vacancy.Id.ToString());
            return View(nameof(Index), model);
        }
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
        private async Task AddLikeVacancyToUserDb(Vacancy vacancy) 
        {
            var guid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // User.Identity!.Name!
            User user = _usersRepository.UserById(guid)!;
            user.LastViewedVacancyId = vacancy.Id;
            user.LastViewedVacancy = vacancy;
            if (user.LikedVacancies is null)
            {
                user.LikedVacancies = new HashSet<Vacancy> { vacancy };
            }
            else
            {
                user.LikedVacancies.Add(vacancy);
            }
            await _usersRepository.UpdateUserAsync(user);
        }
        private async Task WriteUserCookie(HttpContext context, string vacancyId)
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
    }
}

using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace JobsDatingApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        public ProfileController(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet] // [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User loginUser)
        {
            var user = _usersRepository.UserByEmail(loginUser.Email);
            if ((user is not null) && (user.Password.Equals(loginUser.Password)))
            {
                string LastViewedVacancyId = (user.LastViewedVacancyId is null) ? ("") : (user.LastViewedVacancyId.Value.ToString());
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString()),
                    new Claim(CookiesLiterals.LastViewedVacancyId,LastViewedVacancyId)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect("/");
            }
            else {
                //ModelState.AddModelError("", "Dont correct email or password"); // dont work
                TempData["Error"] = "Dont correct email or password";
                return View();
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User registerUser)
        {
            if (_usersRepository.UserByEmail(registerUser.Email) is not null)
            {
                TempData["Error"] = "User with this email already exist";
                return View(registerUser);
            }
            else if (_usersRepository.Users().FirstOrDefault(u => string.Equals(u.Login,registerUser.Login,StringComparison.OrdinalIgnoreCase)) is not null)
            {
                TempData["Error"] = "User with this Login already exist";
                return View(registerUser);
            } else if (!ModelState.IsValid) {
                TempData["Error"] = "Dont correct user data";
                return View(registerUser);
            }
            // all correct
            _usersRepository.AddUser(registerUser);
            return Redirect(nameof(CompleteRegister));
        }
        public IActionResult CompleteRegister() 
        {
            return View();
        }
    }
}

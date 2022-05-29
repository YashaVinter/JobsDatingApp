using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using JobsDatingApp.ViewModels;

namespace JobsDatingApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly Lazy<User> _currentUser;
        public ProfileController(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
            _currentUser = new Lazy<User>(() => FindCurrentUser());
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(new ProfileViewModel { User = _currentUser.Value });
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User loginUser)
        {
            var user = _usersRepository.UserByEmail(loginUser.Email);
            // Validation of user
            if (user is null)
            {
                TempData["Error"] = "User with this Email not found";
                return View();
            }
            if (!string.Equals(user.Password, loginUser.Password))
            {
                TempData["Error"] = "Incorrect password";
                return View();
            }
            // sign in app with cookie
            string LastViewedVacancyId = user.LastViewedVacancy?.VacancyId.ToString() ?? "";
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
            // Validation of user
            if (_usersRepository.UserByEmail(registerUser.Email) is not null)
            {
                TempData["Error"] = "User with this email already exist";
                return View(registerUser);
            }
            if (_usersRepository.Users().Any(u => string.Equals(u.Login, registerUser.Login, StringComparison.OrdinalIgnoreCase)))
            {
                TempData["Error"] = "User with this Login already exist";
                return View(registerUser);
            }
            if (!ModelState.IsValid)
            {
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

        private User FindCurrentUser()
        {
            var guid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _usersRepository.UserById(guid);
        }
    }
}

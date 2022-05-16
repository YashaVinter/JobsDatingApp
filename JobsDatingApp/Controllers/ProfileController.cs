using JobsDatingApp.Data.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobsDatingApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUsersRepository usersRepository;
        public ProfileController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}

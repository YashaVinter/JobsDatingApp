using Microsoft.AspNetCore.Mvc;

namespace JobsDatingApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

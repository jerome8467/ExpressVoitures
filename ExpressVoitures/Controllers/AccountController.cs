using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
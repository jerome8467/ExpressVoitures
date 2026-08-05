using Microsoft.AspNetCore.Mvc;


namespace ExpressVoitures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}

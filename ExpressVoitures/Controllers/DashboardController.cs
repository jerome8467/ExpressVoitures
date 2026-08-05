using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> DashboardIndex()
        {
            DashboardViewModel dashboardViewModel = await _dashboardService.FulldashboardViewModel();
            return View(dashboardViewModel);
        }
    }
}

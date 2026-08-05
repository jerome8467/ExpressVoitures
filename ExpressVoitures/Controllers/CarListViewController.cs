using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using Microsoft.AspNetCore.Mvc;


namespace ExpressVoitures.Controllers
{
    public class CarListViewController : Controller
    {
        private readonly ICarService _carService;

        public CarListViewController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            IEnumerable<CarViewModel> carList = await _carService.GetAllCarViewModel();
            return View(carList);
        }

        [HttpGet]
        public async Task<IActionResult> CarSingle(int id)
        {
            CarViewModel? Car = await _carService.GetCarViewModelById(id);
            return View(Car);
        }


    }
}

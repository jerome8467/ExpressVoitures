using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Controllers
{
    [Authorize]
    public class CarAdminController : Controller
    {
        private readonly ICarService _carService;

        public CarAdminController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult AddCarAdminIndex()
        {
            return View(new CarAdminViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddCarAdminIndex(CarAdminViewModel carAdminViewModel, List<IFormFile> images)
        {
            if (!ModelState.IsValid)
                return View(carAdminViewModel);

            var imageTasks = images.Select(async (image, i) =>
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                string filePath = Path.Combine("wwwroot", "images", "cars", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await image.CopyToAsync(stream);
                return new CarImageViewModel
                {
                    ImagePath = "/images/cars/" + fileName,
                    IsCover = i == 0
                };
            });

            carAdminViewModel.ImagesList = (await Task.WhenAll(imageTasks)).ToList();

            var errors = await _carService.AddCar(carAdminViewModel);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError("", error.ErrorMessage ?? string.Empty);
                return View(carAdminViewModel);
            }

            return RedirectToAction("DashboardIndex", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> EditCarAdminIndex(int id, string tab = "info")
        {
            CarAdminViewModel? carAdminViewModel = await _carService.GetByIdCarAdminViewModel(id);
            if (carAdminViewModel == null) return NotFound();
            ViewBag.Tab = tab;
            return View(carAdminViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditCarAdminIndex(CarAdminViewModel carAdminViewModel, List<IFormFile> images)
        {
            if (!ModelState.IsValid)
                return View(carAdminViewModel);

            var errors = await _carService.UpdateCar(carAdminViewModel);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError("", error.ErrorMessage ?? string.Empty);
                return View(carAdminViewModel);
            }

            return RedirectToAction("DashboardIndex", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCarAdminIndex(int carId)
        {
            await _carService.DeleteCar(carId);
            return RedirectToAction("DashboardIndex", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int imageId, int carId)
        {
            /*await _carService.DeleteCarImage(new CarImageViewModel { ImageId = imageId }, new CarAdminViewModel());
            return Ok();*/
            var car = await _carService.GetByIdCarAdminViewModel(carId);
            if (car == null) return NotFound();
            var image = car.ImagesList?.FirstOrDefault(i => i.ImageId == imageId);
            if (image == null) return NotFound();
            await _carService.DeleteCarImage(image, car);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> SetCover(int imageId, int carId)
        {
            await _carService.SetCarImageAsCover(imageId, carId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddImage([FromForm] IFormFile image, int carId)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine("wwwroot", "images", "cars", fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(stream);

            var car = await _carService.GetByIdCarAdminViewModel(carId);
            if (car == null) return NotFound();

            var imageViewModel = new CarImageViewModel
            {
                ImagePath = "/images/cars/" + fileName,
                IsCover = car.ImagesList?.Count == 0
            };

            await _carService.AddCarImage(imageViewModel, car);
            return Ok(new { imageId = imageViewModel.ImageId });
        }




    }
}
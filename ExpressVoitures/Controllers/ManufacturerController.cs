using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Controllers
{
    [Authorize]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IFinitionService _finitionService;

        public ManufacturerController(IManufacturerService manufacturerService, IVehicleModelService vehicleModelService, IFinitionService finitionService)
        {
            _manufacturerService = manufacturerService;
            _vehicleModelService = vehicleModelService;
            _finitionService = finitionService;
        }

        /*[HttpGet]
        public async Task<IActionResult> ManufacturerIndex(int? ManufacturerId = null, bool fromAddCar = false)
        {
            ManufacturerEditViewModel manufacturerEditViewModel = new ManufacturerEditViewModel
            {
                Manufacturers = await _manufacturerService.GetAllManufacturerViewModel(),
                SelectedManufacturerId = ManufacturerId
            };
            ViewBag.FromAddCar = fromAddCar;

            return View(manufacturerEditViewModel);
        }*/
        [HttpGet]
        public async Task<IActionResult> ManufacturerIndex(int? ManufacturerId = null, bool fromAddCar = false, int? carId = null)
        {
            ManufacturerEditViewModel manufacturerEditViewModel = new ManufacturerEditViewModel
            {
                Manufacturers = await _manufacturerService.GetAllManufacturerViewModel(),
                SelectedManufacturerId = ManufacturerId
            };
            ViewBag.FromAddCar = fromAddCar;
            ViewBag.CarId = carId.HasValue ? (int?)carId.Value : null;
            return View(manufacturerEditViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> GetVehicleModels(int ManufacturerId)
        {
            IEnumerable<VehicleModelViewModel> listVehicleViewModel = await _vehicleModelService.GetAllVehicleModelViewModelByManufacturer(ManufacturerId);
            return Json(listVehicleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetFinitions(int VehicleModelId)
        {
            IEnumerable<FinitionViewModel> listFinitionViewModels = await _finitionService.GetAllFinitionViewModelByVehicleModel(VehicleModelId);
            return Json(listFinitionViewModels);
        }


        [HttpPost]
        public async Task<IActionResult> AddManufacturer([FromBody] ManufacturerViewModel manufacturerViewModel)
        {
            var errors = await _manufacturerService.AddManufacturer(manufacturerViewModel);
            if (errors.Any())
                return BadRequest(errors.Select(e => e.ErrorMessage));

            return Ok(new { id = manufacturerViewModel.Id, name = manufacturerViewModel.Name });
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicleModel([FromBody] VehicleModelViewModel vehicleModelViewModel)
        {
            var errors = await _vehicleModelService.AddVehicleModel(vehicleModelViewModel);
            if (errors.Any())
                return BadRequest(errors.Select(e => e.ErrorMessage));

            return Ok(new { id = vehicleModelViewModel.Id, name = vehicleModelViewModel.Name });
        }

        [HttpPost]
        public async Task<IActionResult> AddFinition([FromBody] FinitionViewModel finitionViewModel)
        {
            var errors = await _finitionService.AddFinition(finitionViewModel);
            if (errors.Any())
                return BadRequest(errors.Select(e => e.ErrorMessage));

            return Ok(new { id = finitionViewModel.Id, name = finitionViewModel.Name });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteManufacturer (int id)
        {
            await _manufacturerService.DeleteManufacturer(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVehicleModel(int id)
        {
            await _vehicleModelService.DeleteVehicleModel(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFinition(int id)
        {
            await _finitionService.DeleteFinition(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManufacturer([FromBody] ManufacturerViewModel manufacturerViewModel)
        {
            var errors = await _manufacturerService.UpdateManufacturer(manufacturerViewModel);
            if (errors.Any())
                return BadRequest(errors.Select(e => e.ErrorMessage));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVehicleModel([FromBody] VehicleModelViewModel vehicleModelViewModel)
        {
            var errors = await _vehicleModelService.UpdateVehicleModel(vehicleModelViewModel);
            if (errors.Any())
                return BadRequest(errors.Select(e => e.ErrorMessage));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFinition([FromBody] FinitionViewModel finitionViewModel)
        {
            var errors = await _finitionService.UpdateFinition(finitionViewModel);
            if (errors.Any())
                return BadRequest(errors.Select(e => e.ErrorMessage));
            return Ok();
        }
    }
}
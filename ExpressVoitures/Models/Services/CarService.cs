using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;

namespace ExpressVoitures.Models.Services
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;
        private readonly ICarRepairRepository _carRepairRepository;
        private readonly ICarTransactionRepository _carTransactionRepository;
        private readonly ICarImageRepository _carImageRepository;
        private readonly IManufacturerService _manufacturerService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IFinitionService _finitionService;


        public CarService(ICarRepository car, ICarRepairRepository carRepair, ICarTransactionRepository carTransaction,
            ICarImageRepository carImage, IManufacturerService manufacturer, IVehicleModelService vehicleModel, IFinitionService finition)
        {
            _carRepository = car;
            _carRepairRepository = carRepair;
            _carTransactionRepository = carTransaction;
            _carImageRepository = carImage;
            _manufacturerService = manufacturer;
            _vehicleModelService = vehicleModel;
            _finitionService = finition;
        }

        /*private async Task<List<CarViewModel>> MapToCarViewModel(IEnumerable<Car> carDb)
        {
            List<CarViewModel> carViewModel = new List<CarViewModel>();
            foreach(var car in carDb)
            {
                double salePrice = car.CarRepair.RepairPrice + car.CarTransaction.PurchasePrice + 500;

                IEnumerable<CarImage> carImageList = car.CarImage ?? Enumerable.Empty<CarImage>();
                List<string> imageUrlList = new List<string>();
                foreach(var imageUrl in carImageList.Where(i => i.IsCover == false).ToList())
                {
                    imageUrlList.Add(imageUrl.ImagePath ?? string.Empty);
                };

                carViewModel.Add(new CarViewModel
                {
                    SalePrice = salePrice,
                    Year = car.Year,
                    Manufacturer = car.Manufacturer?.Name ?? string.Empty,
                    VehicleModel = car.VehicleModel?.Name ?? string.Empty,
                    Finition = car.Finition?.Name ?? string.Empty,
                    Description = car?.Description,
                    ImageCover = carImageList.FirstOrDefault(i => i.IsCover == true)?.ImagePath,
                    ImageList = imageUrlList
                });
            }

            return carViewModel;
        }*/

    }
}

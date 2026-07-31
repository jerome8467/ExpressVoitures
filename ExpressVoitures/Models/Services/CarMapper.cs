using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;

namespace ExpressVoitures.Models.Services
{
    public class CarMapper
    {

        /// <summary>
        /// Converts a collection of Car entities to CarViewModel for public display.
        /// </summary>
        /// <returns>List of CarViewModel for the public view.</returns>
        public static List<CarViewModel> MapToCarViewModel(IEnumerable<Car> carsFromDatabase)
        {
            List<CarViewModel> carViewModel = new List<CarViewModel>();
            foreach (var car in carsFromDatabase)
            {
                double salePrice = car.CarRepair.RepairPrice + car.CarTransaction.PurchasePrice + 500;

                IEnumerable<CarImageViewModel> carImageList = MapToCarImageViewModel(car.CarImage ?? Enumerable.Empty<CarImage>());

                carViewModel.Add(new CarViewModel
                {
                    SalePrice = salePrice,
                    Year = car.Year,
                    Manufacturer = car.Manufacturer?.Name ?? string.Empty,
                    VehicleModel = car.VehicleModel?.Name ?? string.Empty,
                    Finition = car.Finition?.Name ?? string.Empty,
                    Description = car?.Description,
                    ImageCover = carImageList.FirstOrDefault(i => i.IsCover == true)?.ImagePath,
                    ImageList = carImageList.Where(i => i.IsCover == false).ToList()
                });
            }

            return carViewModel;
        }

        /// <summary>
        /// Converts a collection of CarImage entities to CarImageViewModel.
        /// </summary>
        /// <returns>List of CarImageViewModel.</returns>
        public static List<CarImageViewModel> MapToCarImageViewModel(IEnumerable<CarImage> carImagesFromDatabase)
        {
            List<CarImageViewModel> carImageViewModelList = new List<CarImageViewModel>();
            foreach (CarImage carImage in carImagesFromDatabase)
            {
                carImageViewModelList.Add(new CarImageViewModel
                {
                    ImageId = carImage.Id,
                    CarId = carImage.CarId,
                    ImagePath = carImage.ImagePath,
                    IsCover = carImage.IsCover

                });
            }
            return carImageViewModelList;
        }

        public static CarImage MapToCarImageFromDatabase(CarImageViewModel carImageViewModel)
        {
            CarImage carImageNew = new CarImage
            {
                CarId = carImageViewModel.CarId,
                ImagePath = carImageViewModel.ImagePath,
                IsCover = carImageViewModel.IsCover
            };
            return carImageNew;
        }

    }
}

using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;

namespace ExpressVoitures.Models.Services
{
    public class CarMapper
    {

        ///////////////////////// CAR /////////////////////////

        /// <summary>
        /// Converts a single Car entities to CarViewModel for public display.
        /// </summary>
        /// <returns>A single CarViewModel for the public view.</returns>
        public static CarViewModel MapToCarViewModel(Car carsFromDatabase)
        {
                double salePrice = carsFromDatabase.CarRepair.RepairPrice + carsFromDatabase.CarTransaction.PurchasePrice + 500;

                IEnumerable<CarImageViewModel> carImageList = MapToCarImageViewModel(carsFromDatabase.CarImage ?? Enumerable.Empty<CarImage>());

                CarViewModel newCarViewModel = new CarViewModel
                {
                    Id = carsFromDatabase.Id,
                    SalePrice = salePrice,
                    Year = carsFromDatabase.Year,
                    Manufacturer = carsFromDatabase.Manufacturer?.Name ?? string.Empty,
                    VehicleModel = carsFromDatabase.VehicleModel?.Name ?? string.Empty,
                    Finition = carsFromDatabase.Finition?.Name ?? string.Empty,
                    Description = carsFromDatabase?.Description,
                    ImageCover = carImageList.FirstOrDefault(i => i.IsCover == true)?.ImagePath,
                    ImageList = carImageList.Where(i => i.IsCover == false).ToList()
                };

            return newCarViewModel;
        }


        /// <summary>
        /// Converts a single Car entities to CarAdminViewModel for administrateur.
        /// </summary>
        /// <returns>A single CarAdminViewModel for administrateur view.</returns>
        public static CarAdminViewModel MapToCarAdminViewModel(Car carsFromDatabase)
        {
            double salePrice = carsFromDatabase.CarRepair.RepairPrice + carsFromDatabase.CarTransaction.PurchasePrice + 500;

            IEnumerable<CarImageViewModel> carImageList = MapToCarImageViewModel(carsFromDatabase.CarImage ?? Enumerable.Empty<CarImage>());

            CarAdminViewModel newCarAdminViewModel = new CarAdminViewModel
            {
                //SECTION INFORMATION
                CarId = carsFromDatabase.Id,
                SalePrice = salePrice,
                ManufacturerId = carsFromDatabase.ManufacturerId,
                ManufacturerName = carsFromDatabase.Manufacturer?.Name ?? string.Empty,
                VehicleModelId = carsFromDatabase.VehicleModelId,
                VehicleModelName = carsFromDatabase.VehicleModel?.Name ?? string.Empty,
                FinitionId = carsFromDatabase.FinitionId,
                FinitionName = carsFromDatabase.Finition?.Name ?? string.Empty,
                Year = carsFromDatabase.Year.ToString(),
                Kilometer = carsFromDatabase.Kilometer.ToString(),
                Description = carsFromDatabase.Description,

                //SECTION STATUT
                Available = carsFromDatabase.Available,

                //SECTION REPAIR
                CarRepairId = carsFromDatabase.CarRepair.Id,
                RepairPrice = carsFromDatabase.CarRepair.RepairPrice,
                TypeOfRepair = carsFromDatabase.CarRepair.TypeOfRepair,

                //SECTION TRANSACTION
                CarTransactionId = carsFromDatabase.CarTransaction.Id,
                PurchaseDate = carsFromDatabase.CarTransaction.PurchaseDate,
                PurchasePrice = carsFromDatabase.CarTransaction.PurchasePrice,
                AvailabilityDate = carsFromDatabase.CarTransaction.AvailabilityDate,
                SaleDate = carsFromDatabase.CarTransaction.SaleDate,

                //SECTION IMAGE
                ImagesList = carImageList.ToList()

            };

            return newCarAdminViewModel;

        }

        /// <summary>
        /// Converts a single CarAdminViewModel to Car entities.
        /// </summary>
        /// <returns>A single Car.</returns>
        public static Car MapToCarFromDatabase(CarAdminViewModel carAdminViewModel, bool newRecord)
        {
            Car newCar = new Car
            {
                Year = int.Parse(carAdminViewModel.Year),
                Kilometer = int.Parse(carAdminViewModel.Kilometer),
                Description = carAdminViewModel.Description,
                Available = carAdminViewModel.Available,
                ManufacturerId = carAdminViewModel.ManufacturerId,
                VehicleModelId = carAdminViewModel.VehicleModelId,
                FinitionId = carAdminViewModel.FinitionId
            };
            if (!newRecord)
                newCar.Id = carAdminViewModel.CarId;

            return newCar;
        }



        ///////////////////////// CAR IMAGE /////////////////////////

            /// <summary>
            /// Converts a collection of CarImage entities to CarImageViewModel.
            /// </summary>
            /// <returns>A List of CarImageViewModel.</returns>
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

        /// <summary>
        /// Converts a single CarImageViewModel to CarImage entities.
        /// </summary>
        /// <returns>A single CarImage.</returns>
        public static CarImage MapToCarImageFromDatabase(CarImageViewModel carImageViewModel, bool newRecord)
        {
            CarImage newCarImage = new CarImage
            {
                CarId = carImageViewModel.CarId,
                ImagePath = carImageViewModel.ImagePath,
                IsCover = carImageViewModel.IsCover
            };
            if (!newRecord)
                newCarImage.Id = carImageViewModel.ImageId;
            return newCarImage;
        }



        ///////////////////////// CAR REPAIR /////////////////////////

        /// <summary>
        /// Converts a single CarRepair entities to CarRepairViewModel.
        /// </summary>
        /// <returns>A single CarRepairViewModel.</returns>
        public static CarRepairViewModel MapToCarRepairViewModel(CarRepair carRepairsFromDatabase)
        {
            CarRepairViewModel newCarRepairViewModel = new CarRepairViewModel
            {
                Id = carRepairsFromDatabase.Id,
                CarId = carRepairsFromDatabase.CarId,
                RepairPrice = carRepairsFromDatabase.RepairPrice,
                TypeOfRepair = carRepairsFromDatabase.TypeOfRepair,
            };
            return newCarRepairViewModel;
        }

        /// <summary>
        /// Converts a single CarRepairViewModel to CarRepair entities.
        /// </summary>
        /// <returns>A single CarRepair.</returns>
        public static CarRepair MapToCarRepairFromDatabase(CarRepairViewModel carRepairViewModel, bool newRecord)
        {
            CarRepair newCarRepair = new CarRepair
            {
                CarId = carRepairViewModel.CarId,
                RepairPrice = carRepairViewModel.RepairPrice,
                TypeOfRepair = carRepairViewModel.TypeOfRepair
            };
            if (!newRecord)
                newCarRepair.Id = carRepairViewModel.Id;
            return newCarRepair;
        }

        /// <summary>
        /// Converts a single CarAdminViewModel to CarRepair entities.
        /// </summary>
        /// <returns>A single CarRepair.</returns>
        public static CarRepair MapCarAdminViewModelToCarRepairFromDatabase(CarAdminViewModel carAdminViewModel, bool newRecord)
        {
            CarRepair newCarRepair = new CarRepair
            {
                CarId = carAdminViewModel.CarId,
                RepairPrice = carAdminViewModel.RepairPrice,
                TypeOfRepair = carAdminViewModel.TypeOfRepair,
            };
            if (!newRecord)
                newCarRepair.Id = carAdminViewModel.CarRepairId;
            return newCarRepair;
        }



        ///////////////////////// CAR TRANSACTION /////////////////////////

        /// <summary>
        /// Converts a single CarTransaction entities to CarTransactionViewModel.
        /// </summary>
        /// <returns>A single CarTransactionViewModel.</returns>
        public static CarTransactionViewModel MapToCarTransactionViewModel(CarTransaction carTransactionsFromDatabase)
        {
                CarTransactionViewModel newCarTransactionViewModel = new CarTransactionViewModel
                {
                    Id = carTransactionsFromDatabase.Id,
                    CarId = carTransactionsFromDatabase.CarId,
                    PurchaseDate = carTransactionsFromDatabase.PurchaseDate,
                    PurchasePrice = carTransactionsFromDatabase.PurchasePrice,
                    AvailabilityDate = carTransactionsFromDatabase.AvailabilityDate,
                    SaleDate = carTransactionsFromDatabase.SaleDate,
                };
            return newCarTransactionViewModel;
        }

        /// <summary>
        /// Converts a single CarTransactionViewModel to CarTransaction entities.
        /// </summary>
        /// <returns>A single CarTransaction.</returns>
        public static CarTransaction MapToCarTransactionFromDatabase(CarTransactionViewModel carTransactionViewModel, bool newRecord)
        {
            CarTransaction newCarTransaction = new CarTransaction
            {
                CarId = carTransactionViewModel.CarId,
                PurchaseDate = carTransactionViewModel.PurchaseDate,
                PurchasePrice = carTransactionViewModel.PurchasePrice,
                AvailabilityDate = carTransactionViewModel.AvailabilityDate,
                SaleDate = carTransactionViewModel.SaleDate,
            };
            if (!newRecord)
                newCarTransaction.Id = carTransactionViewModel.Id;
            return newCarTransaction;
        }

        /// <summary>
        /// Converts a single CarAdminViewModel to CarTransaction entities.
        /// </summary>
        /// <returns>A single CarTransaction.</returns>
        public static CarTransaction MapToCarAdminViewModelTransactionFromDatabase(CarAdminViewModel carAdminViewModel, bool newRecord)
        {
            CarTransaction newCarTransaction = new CarTransaction
            {
                CarId = carAdminViewModel.CarId,
                PurchaseDate = carAdminViewModel.PurchaseDate,
                PurchasePrice = carAdminViewModel.PurchasePrice,
                AvailabilityDate = carAdminViewModel.AvailabilityDate,
                SaleDate = carAdminViewModel.SaleDate,
            };
            if (!newRecord)
                newCarTransaction.Id = carAdminViewModel.CarTransactionId;
            return newCarTransaction;
        }







    }
}

using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;
        private readonly ICarRepairRepository _carRepairRepository;
        private readonly ICarTransactionRepository _carTransactionRepository;
        private readonly ICarImageRepository _carImageRepository;



        public CarService(ICarRepository car, ICarRepairRepository carRepair, ICarTransactionRepository carTransaction,
            ICarImageRepository carImage)
        {
            _carRepository = car;
            _carRepairRepository = carRepair;
            _carTransactionRepository = carTransaction;
            _carImageRepository = carImage;

        }


        public async Task<IEnumerable<CarViewModel>> GetAllCarViewModel()
        {
            IEnumerable<Car> carFromDatabase = await _carRepository.GetAllCar();
            List<CarViewModel> carViewModelList = new List<CarViewModel>();
            foreach (Car car in carFromDatabase.Where(s => s.Status == CarStatus.ForSale)) 
            {
                carViewModelList.Add(CarMapper.MapToCarViewModel(car, false));
            }

            return carViewModelList;

        }


        public async Task<IEnumerable<CarAdminViewModel>> GetAllCarAdminViewModel()
        {
            IEnumerable<Car> carFromDatabase = await _carRepository.GetAllCar();
            List<CarAdminViewModel> carAdminViewModelList = new List<CarAdminViewModel>();
            foreach(Car car in carFromDatabase)
            {
                carAdminViewModelList.Add(CarMapper.MapToCarAdminViewModel(car, false));
            }

            return carAdminViewModelList;

        }


        public async Task<CarViewModel?> GetCarViewModelById(int id)
        {
            Car? carDatabase = await _carRepository.GetByIdCar(id);
            if (carDatabase == null) return null;
                CarViewModel carViewModel = CarMapper.MapToCarViewModel(carDatabase, true);
            return carViewModel;

        }


        public async Task<CarAdminViewModel?> GetByIdCarAdminViewModel(int id)
        {
            Car? carDatabase = await _carRepository.GetByIdCar(id);
            if (carDatabase == null) return null;
            CarAdminViewModel carAdminViewModel = CarMapper.MapToCarAdminViewModel(carDatabase, true);
            return carAdminViewModel;
        }


        public async Task<List<ValidationResult>> AddCar(CarAdminViewModel carAdminViewModel)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(carAdminViewModel);

            if (!Validator.TryValidateObject(carAdminViewModel, context, errors, true))
                return errors;

            Car carFromDatabase = CarMapper.MapToCarFromDatabase(carAdminViewModel, true);
                await _carRepository.AddCar(carFromDatabase);

            carAdminViewModel.CarId = carFromDatabase.Id;

            CarRepair carRepairFromDatabase = CarMapper.MapCarAdminViewModelToCarRepairFromDatabase(carAdminViewModel, true);
                await _carRepairRepository.AddCarRepair(carRepairFromDatabase);

            CarTransaction carTransactionFromDatabase = CarMapper.MapCarAdminViewModelToCarTransactionFromDatabase(carAdminViewModel, true);
                await _carTransactionRepository.AddCarTransaction(carTransactionFromDatabase);

            foreach (var carImageList in carAdminViewModel.ImagesList ?? Enumerable.Empty<CarImageViewModel>())
            {
                CarImage carImage = CarMapper.MapToCarImageFromDatabase(carImageList, true);
                carImage.CarId = carFromDatabase.Id;
                await _carImageRepository.AddCarImage(carImage);
            };

            return new List<ValidationResult>();
        }

        public async Task<List<ValidationResult>> UpdateCar(CarAdminViewModel carAdminViewModel)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(carAdminViewModel);

            if (!Validator.TryValidateObject(carAdminViewModel, context, errors, true))
                return errors;

            Car carForUpdate = CarMapper.MapToCarFromDatabase(carAdminViewModel, false);
            CarRepair carRepairForUpdate = CarMapper.MapCarAdminViewModelToCarRepairFromDatabase(carAdminViewModel, false);
            CarTransaction carTransactionForUpdate = CarMapper.MapCarAdminViewModelToCarTransactionFromDatabase(carAdminViewModel, false);

            await _carRepository.UpdateCar(carForUpdate, carRepairForUpdate, carTransactionForUpdate);

            return new List<ValidationResult>();
        }

        public async Task DeleteCar(CarAdminViewModel carAdminViewModel)
        {
            await _carRepository.DeleteCar(carAdminViewModel.CarId);
        }


        public async Task AddCarImage(CarImageViewModel carImageViewModel, CarAdminViewModel carAdminViewModel)
        {
            if (carAdminViewModel.ImagesList?.Count == 0) carImageViewModel.IsCover = true;
            
            CarImage carImage = CarMapper.MapToCarImageFromDatabase(carImageViewModel, true);
            await _carImageRepository.AddCarImage(carImage);

            carImageViewModel.ImageId = carImage.Id;
            carAdminViewModel.ImagesList?.Add(carImageViewModel);
        }


        public async Task DeleteCarImage(CarImageViewModel carImageViewModel, CarAdminViewModel carAdminViewModel)
        {
            await _carImageRepository.DeleteCarImage(carImageViewModel.ImageId);
            carAdminViewModel.ImagesList?.Remove(carImageViewModel);

            if (carAdminViewModel.ImagesList?.Count == 0)
            {
                return;
            }

            if (carImageViewModel.IsCover == true)
            {
                CarImageViewModel? carImageViewModelNewCover = carAdminViewModel.ImagesList?.First();
                carImageViewModelNewCover!.IsCover = true;
                CarImage carImageFromDatabase = CarMapper.MapToCarImageFromDatabase(carImageViewModelNewCover, false);
                await _carImageRepository.UpdateCarImage(carImageFromDatabase);
                return;
            }
        }

        public async Task SetCarImageAsCover(CarImageViewModel carImageViewModel, CarAdminViewModel carAdminViewModel)
        {
            carImageViewModel.IsCover = true;

            CarImageViewModel? carImageOldTrue = carAdminViewModel.ImagesList?.FirstOrDefault(c => c.IsCover == true);
            if (carImageOldTrue != null)
            {
                carImageOldTrue.IsCover = false;

                CarImage carImageFromDatabaseFalse = CarMapper.MapToCarImageFromDatabase(carImageOldTrue, false);
                await _carImageRepository.UpdateCarImage(carImageFromDatabaseFalse);
            }

            CarImage carImageFromDatabaseTrue = CarMapper.MapToCarImageFromDatabase(carImageViewModel, false);
            await _carImageRepository.UpdateCarImage(carImageFromDatabaseTrue);

        }

        

    }
}

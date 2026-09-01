using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace ExpressVoituresTest.IntegrationTests
{
    public class CarServiceIntegration
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICarRepository _carRepository;
        private readonly ICarRepairRepository _carRepairRepository;
        private readonly ICarTransactionRepository _carTransactionRepository;
        private readonly ICarImageRepository _carImageRepository;
        private readonly ICarService _carService;

        public CarServiceIntegration()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=:memory:")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();

            _dbContext.Manufacturer.Add(new Manufacturer { Id = 1, Name = "Toyota" });
            _dbContext.Manufacturer.Add(new Manufacturer { Id = 2, Name = "Peugeot" });
            _dbContext.SaveChanges();
            _dbContext.VehicleModel.Add(new VehicleModel { Id = 1, Name = "CHR", ManufacturerId = 1 });
            _dbContext.VehicleModel.Add(new VehicleModel { Id = 2, Name = "306", ManufacturerId = 2 });
            _dbContext.SaveChanges();
            _dbContext.Finition.Add(new Finition { Id = 1, Name = "Graphique", VehicleModelId = 1 });
            _dbContext.Finition.Add(new Finition { Id = 2, Name = "Line", VehicleModelId = 2 });
            _dbContext.SaveChanges();

            _carRepository = new CarRepository(_dbContext);
            _carRepairRepository = new CarRepairRepository(_dbContext);
            _carTransactionRepository = new CarTransactionRepository(_dbContext);
            _carImageRepository = new CarImageRepository(_dbContext);
            _carService = new CarService(_carRepository, _carRepairRepository, _carTransactionRepository, _carImageRepository);

        }


        [Fact]
        public async Task AddCarAdminTest()
        {
            // Arrange
            List<CarImageViewModel> NewListImage = new List<CarImageViewModel> {
                new CarImageViewModel {CarId = 0, ImagePath = "/images/cars/new1.jpg", IsCover = true },
                new CarImageViewModel {CarId = 0, ImagePath = "/images/cars/new2.jpg", IsCover = false } };
            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                Description = "Voiture test",
                Status = CarStatus.ForSale,
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                AdditionalAmount = 500,
                AvailabilityDate = new DateOnly(2025, 4, 1),
                SaleDate = new DateOnly(2025, 5, 1),
                ImagesList = NewListImage
            };

            // Act
            await _carService.AddCar(carAdminViewModel);
            CarAdminViewModel? result = await _carService.GetByIdCarAdminViewModel(carAdminViewModel.CarId);

            // Assert
            Assert.NotNull(result);

            Assert.Equal("Toyota", result.ManufacturerName);
            Assert.Equal("CHR", result.VehicleModelName);
            Assert.Equal("Graphique", result.FinitionName);

            Assert.Equal(8500, result.SalePrice);
            Assert.Equal("2021", result.Year);
            Assert.Equal("30000", result.Kilometer);
            Assert.Equal("Voiture test", result.Description);

            Assert.Equal(CarStatus.ForSale, result.Status);

            Assert.Equal("2000", result.RepairPrice);
            Assert.Equal("Freins", result.TypeOfRepair);

            Assert.Equal(new DateOnly(2025, 3, 1), result.PurchaseDate);
            Assert.Equal("6000", result.PurchasePrice);
            Assert.Equal(500, result.AdditionalAmount);
            Assert.Equal(new DateOnly(2025, 4, 1), result.AvailabilityDate);
            Assert.Equal(new DateOnly(2025, 5, 1), result.SaleDate);

            Assert.Equal(2, result.ImagesList?.Count);

        }

        [Fact]
        public async Task UpdateCarAdminTest()
        {
            // Arrange
            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                Description = "Voiture test",
                Status = CarStatus.ForSale,
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                AdditionalAmount = 500,
                AvailabilityDate = new DateOnly(2025, 4, 1),
                SaleDate = new DateOnly(2025, 5, 1),
            };
            await _carService.AddCar(carAdminViewModel);
            _dbContext.ChangeTracker.Clear();
            CarAdminViewModel? newCarAdminViewModel = await _carService.GetByIdCarAdminViewModel(carAdminViewModel.CarId);
            _dbContext.ChangeTracker.Clear();

            // Act
            newCarAdminViewModel!.ManufacturerId = 2;
            newCarAdminViewModel.VehicleModelId = 2;
            newCarAdminViewModel.FinitionId = 2;
            newCarAdminViewModel.Year = "2022";
            newCarAdminViewModel.Kilometer = "40000";
            newCarAdminViewModel.Description = "Voiture test after update";
            newCarAdminViewModel.Status = CarStatus.Sold;
            newCarAdminViewModel.RepairPrice = "3000";
            newCarAdminViewModel.TypeOfRepair = "Freins after update";
            newCarAdminViewModel.PurchaseDate = new DateOnly(2026, 3, 1);
            newCarAdminViewModel.PurchasePrice = "7000";
            newCarAdminViewModel.AdditionalAmount = 1000;
            newCarAdminViewModel.AvailabilityDate = new DateOnly(2026, 4, 1);
            newCarAdminViewModel.SaleDate = new DateOnly(2026, 5, 1);

            await _carService.UpdateCar(newCarAdminViewModel);
            CarAdminViewModel? result = await _carService.GetByIdCarAdminViewModel(newCarAdminViewModel.CarId);

            // Assert
            Assert.NotNull(result);

            Assert.Equal("Peugeot", result.ManufacturerName);
            Assert.Equal("306", result.VehicleModelName);
            Assert.Equal("Line", result.FinitionName);

            Assert.Equal(11000, result.SalePrice);
            Assert.Equal("2022", result.Year);
            Assert.Equal("40000", result.Kilometer);
            Assert.Equal("Voiture test after update", result.Description);

            Assert.Equal(CarStatus.Sold, result.Status);

            Assert.Equal("3000", result.RepairPrice);
            Assert.Equal("Freins after update", result.TypeOfRepair);

            Assert.Equal(new DateOnly(2026, 3, 1), result.PurchaseDate);
            Assert.Equal("7000", result.PurchasePrice);
            Assert.Equal(1000, result.AdditionalAmount);
            Assert.Equal(new DateOnly(2026, 4, 1), result.AvailabilityDate);
            Assert.Equal(new DateOnly(2026, 5, 1), result.SaleDate);

        }

        [Fact]
        public async Task DeleteCarAdminTest()
        {
            // Arrange
            List<CarImageViewModel> ListImageToAdd = new List<CarImageViewModel> {
                new CarImageViewModel {CarId = 0, ImagePath = "/images/cars/new1.jpg", IsCover = true },
                new CarImageViewModel {CarId = 0, ImagePath = "/images/cars/new2.jpg", IsCover = false } };
            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                ImagesList = ListImageToAdd
            };
            await _carService.AddCar(carAdminViewModel);

            // Act
            await _carService.DeleteCar(carAdminViewModel.CarId);

            IEnumerable<Car> ListCar = await _carRepository.GetAllCar();
            IEnumerable<CarRepair> ListCarRepair = await _carRepairRepository.GetAllCarRepair();
            IEnumerable<CarTransaction> ListCarTransaction = await _carTransactionRepository.GetAllCarTransaction();
            IEnumerable<CarImage> ListImage = await _carImageRepository.GetAllCarImageByIdCar(carAdminViewModel.CarId);

            // Assert
            Assert.DoesNotContain(ListCar, i => i.Id == carAdminViewModel.CarId);
            Assert.DoesNotContain(ListCarRepair, i => i.Id == carAdminViewModel.CarRepairId);
            Assert.DoesNotContain(ListCarTransaction, i => i.Id == carAdminViewModel.CarTransactionId);
            Assert.Empty(ListImage);
        }

        [Fact]
        public async Task GetAllCarViewModelTest()
        {
            // Arrange
            CarAdminViewModel carAdminViewModel1 = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                Status = CarStatus.InRepair,
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
            };
            CarAdminViewModel carAdminViewModel2 = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                Status = CarStatus.ForSale,
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
            };
            CarAdminViewModel carAdminViewModel3 = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                Status = CarStatus.Sold,
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
            };
            await _carService.AddCar(carAdminViewModel1);
            await _carService.AddCar(carAdminViewModel2);
            await _carService.AddCar(carAdminViewModel3);

            // Act
            IEnumerable<CarViewModel> ListCarViewModel = await _carService.GetAllCarViewModel();
            int countList = ListCarViewModel.Count();

            // Assert
            Assert.Equal(1, countList);
            Assert.DoesNotContain(ListCarViewModel, i => i.Id == carAdminViewModel1.CarId);
            Assert.Contains(ListCarViewModel, i => i.Id == carAdminViewModel2.CarId);
            Assert.DoesNotContain(ListCarViewModel, i => i.Id == carAdminViewModel3.CarId);
        }

        [Fact]
        public async Task AddCarImageTest()
        {
            // Arrange
            List<CarImageViewModel> ListImageToAdd = new List<CarImageViewModel> {
                new CarImageViewModel {CarId = 0, ImagePath = "/images/cars/new1.jpg", IsCover = true },
                new CarImageViewModel {CarId = 0, ImagePath = "/images/cars/new2.jpg", IsCover = false } };
            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                ImagesList = ListImageToAdd
            };
            await _carService.AddCar(carAdminViewModel);

            // Act
            CarImageViewModel carImageNew = new CarImageViewModel { CarId = carAdminViewModel.CarId, ImagePath = "/images/cars/new3.jpg", IsCover = false };
            await _carService.AddCarImage(carImageNew, carAdminViewModel);
            int imgCount = carAdminViewModel.ImagesList.Count();
            int imgFalse = carAdminViewModel.ImagesList.Where(i => i.IsCover == false).Count();
            int imgTrue = carAdminViewModel.ImagesList.Where(i => i.IsCover == true).Count();

            // Assert
            Assert.Equal(3, imgCount);
            Assert.Equal(2, imgFalse);
            Assert.Equal(1, imgTrue);
            Assert.Contains(carAdminViewModel.ImagesList, i => i.ImageId == carImageNew.ImageId);
        }

        [Fact]
        public async Task DeleteCarImageFalseCoverTest()
        {
            // Arrange
            List<CarImageViewModel> ListImageToAdd = new List<CarImageViewModel> {
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new1.jpg", IsCover = true },
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new2.jpg", IsCover = false },
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new3.jpg", IsCover = false }};

            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                ImagesList = ListImageToAdd
            };
            await _carService.AddCar(carAdminViewModel);
            CarImageViewModel? carImageFalse = carAdminViewModel.ImagesList.Where(
                c => c.IsCover == false && 
                c.ImagePath == "/images/cars/new2.jpg")
                .FirstOrDefault();

            // Act
            if(carImageFalse != null)
            await _carService.DeleteCarImage(carImageFalse, carAdminViewModel);
            int imageFalse = carAdminViewModel.ImagesList.Where(c => c.IsCover == false).Count();
            int imageTrue = carAdminViewModel.ImagesList.Where(c => c.IsCover == true).Count();
            int ImageCount = carAdminViewModel.ImagesList.Count();

            // Assert
            Assert.Equal(1, imageTrue);
            Assert.Equal(1, imageFalse);
            Assert.Equal(2, ImageCount);
            Assert.DoesNotContain(carAdminViewModel.ImagesList, i => i.ImagePath == "/images/cars/new2.jpg");
            Assert.Contains(carAdminViewModel.ImagesList, i => i.ImagePath == "/images/cars/new1.jpg");
            Assert.Contains(carAdminViewModel.ImagesList, i => i.ImagePath == "/images/cars/new3.jpg");

        }

        [Fact]
        public async Task DeleteCarImageTrueCoverTest()
        {
            // Arrange
            List<CarImageViewModel> ListImageToAdd = new List<CarImageViewModel> {
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new1.jpg", IsCover = false },
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new2.jpg", IsCover = false },
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new3.jpg", IsCover = true }};

            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                ImagesList = ListImageToAdd
            };
            await _carService.AddCar(carAdminViewModel);
            CarImageViewModel? carImageTrue = carAdminViewModel.ImagesList.Where(
                c => c.IsCover == true &&
                c.ImagePath == "/images/cars/new3.jpg")
                .FirstOrDefault();

            // Act
            if (carImageTrue != null)
                await _carService.DeleteCarImage(carImageTrue, carAdminViewModel);
            int imageFalse = carAdminViewModel.ImagesList.Where(c => c.IsCover == false).Count();
            int imageTrue = carAdminViewModel.ImagesList.Where(c => c.IsCover == true).Count();
            int? imageTrueId = carAdminViewModel.ImagesList.Where(c => c.IsCover == true).FirstOrDefault()?.ImageId;
            int ImageCount = carAdminViewModel.ImagesList.Count();

            // Assert
            Assert.Equal(1, imageTrue);
            Assert.Equal(1, imageFalse);
            Assert.Equal(2, ImageCount);
            Assert.NotNull(imageTrueId);
            Assert.DoesNotContain(carAdminViewModel.ImagesList, i => i.ImagePath == "/images/cars/new3.jpg");
            Assert.Contains(carAdminViewModel.ImagesList, i => i.IsCover == true && i.ImagePath == "/images/cars/new1.jpg");
            Assert.Contains(carAdminViewModel.ImagesList, i => i.IsCover == false && i.ImagePath == "/images/cars/new2.jpg");

        }

        [Fact]
        public async Task SetAsCoverCarImageTest()
        {
            // Arrange
            List<CarImageViewModel> ListImageToAdd = new List<CarImageViewModel> {
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new1.jpg", IsCover = false },
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new2.jpg", IsCover = false },
                new CarImageViewModel {CarId=0, ImagePath = "/images/cars/new3.jpg", IsCover = true }};

            CarAdminViewModel carAdminViewModel = new CarAdminViewModel
            {
                ManufacturerId = 1,
                VehicleModelId = 1,
                FinitionId = 1,
                Year = "2021",
                Kilometer = "30000",
                RepairPrice = "2000",
                TypeOfRepair = "Freins",
                PurchaseDate = new DateOnly(2025, 3, 1),
                PurchasePrice = "6000",
                ImagesList = ListImageToAdd
            };
            await _carService.AddCar(carAdminViewModel);
            _dbContext.ChangeTracker.Clear();

            CarAdminViewModel? freshCar = await _carService.GetByIdCarAdminViewModel(carAdminViewModel.CarId);
            int carId = freshCar!.CarId;
            int imageIdFuturTrue = freshCar.ImagesList!.Where(c => c.IsCover == false && c.ImagePath == "/images/cars/new2.jpg").FirstOrDefault()!.ImageId;
            _dbContext.ChangeTracker.Clear();

            // Act
            await _carService.SetCarImageAsCover(imageIdFuturTrue, carId);
            _dbContext.ChangeTracker.Clear();

            CarAdminViewModel? result = await _carService.GetByIdCarAdminViewModel(carId);

            // Assert
            Assert.Contains(result!.ImagesList!, c => c.IsCover == true && c.ImagePath == "/images/cars/new2.jpg");
            Assert.Contains(result.ImagesList!, c => c.IsCover == false && c.ImagePath == "/images/cars/new1.jpg");
            Assert.Contains(result.ImagesList!, c => c.IsCover == false && c.ImagePath == "/images/cars/new3.jpg");

        }


    }
}

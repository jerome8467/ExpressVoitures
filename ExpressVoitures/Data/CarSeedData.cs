using ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Data
{
    public class CarSeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Car.Any())
                return;


            /////////////////////// VOLKSWAGEN ///////////////////////
            var volkswagen = context.Manufacturer.First(m => m.Name == "Volkswagen");

            var golfVolkswagen = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Golf" && v.Manufacturer!.Name == "Volkswagen");
            var lifeVolkswagen = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Life" && f.VehicleModel!.Name == "Golf");

            var poloVolkswagen = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Polo" && v.Manufacturer!.Name == "Volkswagen");
            var confortlineVolkswagen = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Confortline" && f.VehicleModel!.Name == "Polo");

            var carGolf = new Car
            {
                Year = 2021,
                Kilometer = 60131,
                Description = "Description Volkswagen Golf à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = volkswagen.Id,
                VehicleModelId = golfVolkswagen.Id,
                FinitionId = lifeVolkswagen.Id,
            };
            context.Car.Add(carGolf);
            await context.SaveChangesAsync();

            var repairCarGolf = new CarRepair
            {
                RepairPrice = 3000,
                TypeOfRepair = "Réparation Volkswagen Golf à compléter",
                CarId = carGolf.Id
            };
            context.CarRepair.Add(repairCarGolf);
            await context.SaveChangesAsync();

            var transactionCarGolf = new CarTransaction
            {
                PurchaseDate = new DateOnly(2023, 1, 15),
                PurchasePrice = 12500,
                AvailabilityDate = new DateOnly(2023, 2, 10),
                CarId = carGolf.Id
            };
            context.CarTransaction.Add(transactionCarGolf);
            await context.SaveChangesAsync();

            var imageCarGolf_1 = new CarImage { CarId = carGolf.Id,  IsCover = true, ImagePath = "/images/cars/golf 1.png"};
            var imageCarGolf_2 = new CarImage { CarId = carGolf.Id, IsCover = false, ImagePath = "/images/cars/golf 2.png" };
            var imageCarGolf_3 = new CarImage { CarId = carGolf.Id, IsCover = false, ImagePath = "/images/cars/golf 3.png" };
            context.CarImage.AddRange(imageCarGolf_1, imageCarGolf_2, imageCarGolf_3);
            await context.SaveChangesAsync();


            var carPolo = new Car
            {
                Year = 2022,
                Kilometer = 80131,
                Description = "Description Volkswagen Polo à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = volkswagen.Id,
                VehicleModelId = poloVolkswagen.Id,
                FinitionId = confortlineVolkswagen.Id,
            };
            context.Car.Add(carPolo);
            await context.SaveChangesAsync();

            var repairCarPolo = new CarRepair
            {
                RepairPrice = 2000,
                TypeOfRepair = "Réparation Volkswagen Polo à compléter",
                CarId = carPolo.Id
            };
            context.CarRepair.Add(repairCarPolo);
            await context.SaveChangesAsync();

            var transactionCarPolo = new CarTransaction
            {
                PurchaseDate = new DateOnly(2024, 1, 15),
                PurchasePrice = 9500,
                AvailabilityDate = new DateOnly(2024, 2, 10),
                CarId = carPolo.Id
            };
            context.CarTransaction.Add(transactionCarPolo);
            await context.SaveChangesAsync();

            var imageCarPolo_1 = new CarImage { CarId = carPolo.Id, IsCover = true, ImagePath = "/images/cars/polo 1.png" };
            var imageCarPolo_2 = new CarImage { CarId = carPolo.Id, IsCover = false, ImagePath = "/images/cars/polo 2.png" };
            var imageCarPolo_3 = new CarImage { CarId = carPolo.Id, IsCover = false, ImagePath = "/images/cars/polo 3.png" };
            context.CarImage.AddRange(imageCarPolo_1, imageCarPolo_2, imageCarPolo_3);
            await context.SaveChangesAsync();


            /////////////////////// TOYOTA ///////////////////////
            var toyota = context.Manufacturer.First(m => m.Name == "Toyota");

            var corollaToyota = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Corolla" && v.Manufacturer!.Name == "Toyota");
            var grsportToyota = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "GR SPORT" && f.VehicleModel!.Name == "Corolla");

            var ravToyota = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "RAV4" && v.Manufacturer!.Name == "Toyota");
            var dynamicToyota = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Dynamic" && f.VehicleModel!.Name == "RAV4");

            var carCorolla = new Car
            {
                Year = 2023,
                Kilometer = 40131,
                Description = "Description Toyota Corolla à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = toyota.Id,
                VehicleModelId = corollaToyota.Id,
                FinitionId = grsportToyota.Id,
            };
            context.Car.Add(carCorolla);
            await context.SaveChangesAsync();

            var repairCarCorolla = new CarRepair
            {
                RepairPrice = 4000,
                TypeOfRepair = "Réparation Toyota Corolla à compléter",
                CarId = carCorolla.Id
            };
            context.CarRepair.Add(repairCarCorolla);
            await context.SaveChangesAsync();

            var transactionCarCorolla = new CarTransaction
            {
                PurchaseDate = new DateOnly(2025, 1, 15),
                PurchasePrice = 19500,
                AvailabilityDate = new DateOnly(2025, 2, 10),
                CarId = carCorolla.Id
            };
            context.CarTransaction.Add(transactionCarCorolla);
            await context.SaveChangesAsync();

            var imageCarCorolla_1 = new CarImage { CarId = carCorolla.Id, IsCover = true, ImagePath = "/images/cars/corolla 1.png" };
            var imageCarCorolla_2 = new CarImage { CarId = carCorolla.Id, IsCover = false, ImagePath = "/images/cars/corolla 2.png" };
            var imageCarCorolla_3 = new CarImage { CarId = carCorolla.Id, IsCover = false, ImagePath = "/images/cars/corolla 3.png" };
            context.CarImage.AddRange(imageCarCorolla_1, imageCarCorolla_2, imageCarCorolla_3);
            await context.SaveChangesAsync();


            var carRav4 = new Car
            {
                Year = 2022,
                Kilometer = 55000,
                Description = "Description Toyota RAV4 à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = toyota.Id,
                VehicleModelId = ravToyota.Id,
                FinitionId = dynamicToyota.Id,
            };
            context.Car.Add(carRav4);
            await context.SaveChangesAsync();

            var repairCarRav4 = new CarRepair
            {
                RepairPrice = 3500,
                TypeOfRepair = "Réparation Toyota RAV4 à compléter",
                CarId = carRav4.Id
            };
            context.CarRepair.Add(repairCarRav4);
            await context.SaveChangesAsync();

            var transactionCarRav4 = new CarTransaction
            {
                PurchaseDate = new DateOnly(2024, 6, 10),
                PurchasePrice = 22000,
                AvailabilityDate = new DateOnly(2024, 7, 5),
                CarId = carRav4.Id
            };
            context.CarTransaction.Add(transactionCarRav4);
            await context.SaveChangesAsync();

            var imageCarRav4_1 = new CarImage { CarId = carRav4.Id, IsCover = true, ImagePath = "/images/cars/rav 1.png" };
            var imageCarRav4_2 = new CarImage { CarId = carRav4.Id, IsCover = false, ImagePath = "/images/cars/rav 2.png" };
            var imageCarRav4_3 = new CarImage { CarId = carRav4.Id, IsCover = false, ImagePath = "/images/cars/rav 3.png" };
            context.CarImage.AddRange(imageCarRav4_1, imageCarRav4_2, imageCarRav4_3);
            await context.SaveChangesAsync();


            /////////////////////// FORD ///////////////////////
            var ford = context.Manufacturer.First(m => m.Name == "Ford");

            var mustangFord = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Mustang" && v.Manufacturer!.Name == "Ford");
            var matcheFord = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "MACH-E" && f.VehicleModel!.Name == "Mustang");

            var fiestaFord = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Fiesta" && v.Manufacturer!.Name == "Ford");
            var activeFord = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Active" && f.VehicleModel!.Name == "Fiesta");

            var carMustang = new Car
            {
                Year = 2023,
                Kilometer = 25000,
                Description = "Description Ford Mustang à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = ford.Id,
                VehicleModelId = mustangFord.Id,
                FinitionId = matcheFord.Id,
            };
            context.Car.Add(carMustang);
            await context.SaveChangesAsync();

            var repairCarMustang = new CarRepair
            {
                RepairPrice = 2500,
                TypeOfRepair = "Réparation Ford Mustang à compléter",
                CarId = carMustang.Id
            };
            context.CarRepair.Add(repairCarMustang);
            await context.SaveChangesAsync();

            var transactionCarMustang = new CarTransaction
            {
                PurchaseDate = new DateOnly(2024, 3, 20),
                PurchasePrice = 35000,
                AvailabilityDate = new DateOnly(2024, 4, 15),
                CarId = carMustang.Id
            };
            context.CarTransaction.Add(transactionCarMustang);
            await context.SaveChangesAsync();

            var imageCarMustang_1 = new CarImage { CarId = carMustang.Id, IsCover = true, ImagePath = "/images/cars/mustang 1.png" };
            var imageCarMustang_2 = new CarImage { CarId = carMustang.Id, IsCover = false, ImagePath = "/images/cars/mustang 2.png" };
            var imageCarMustang_3 = new CarImage { CarId = carMustang.Id, IsCover = false, ImagePath = "/images/cars/mustang 3.png" };
            context.CarImage.AddRange(imageCarMustang_1, imageCarMustang_2, imageCarMustang_3);
            await context.SaveChangesAsync();

            var carFiesta = new Car
            {
                Year = 2021,
                Kilometer = 70000,
                Description = "Description Ford Fiesta à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = ford.Id,
                VehicleModelId = fiestaFord.Id,
                FinitionId = activeFord.Id,
            };
            context.Car.Add(carFiesta);
            await context.SaveChangesAsync();

            var repairCarFiesta = new CarRepair
            {
                RepairPrice = 1500,
                TypeOfRepair = "Réparation Ford Fiesta à compléter",
                CarId = carFiesta.Id
            };
            context.CarRepair.Add(repairCarFiesta);
            await context.SaveChangesAsync();

            var transactionCarFiesta = new CarTransaction
            {
                PurchaseDate = new DateOnly(2023, 8, 5),
                PurchasePrice = 8500,
                AvailabilityDate = new DateOnly(2023, 9, 1),
                CarId = carFiesta.Id
            };
            context.CarTransaction.Add(transactionCarFiesta);
            await context.SaveChangesAsync();

            var imageCarFiesta_1 = new CarImage { CarId = carFiesta.Id, IsCover = true, ImagePath = "/images/cars/fiesta 1.png" };
            var imageCarFiesta_2 = new CarImage { CarId = carFiesta.Id, IsCover = false, ImagePath = "/images/cars/fiesta 2.png" };
            var imageCarFiesta_3 = new CarImage { CarId = carFiesta.Id, IsCover = false, ImagePath = "/images/cars/fiesta 3.png" };
            context.CarImage.AddRange(imageCarFiesta_1, imageCarFiesta_2, imageCarFiesta_3);
            await context.SaveChangesAsync();


            /////////////////////// RENAULT ///////////////////////
            var renault = context.Manufacturer.First(m => m.Name == "Renault");

            var clioRenault = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Clio" && v.Manufacturer!.Name == "Renault");
            var intensRenault = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Intens" && f.VehicleModel!.Name == "Clio");

            var scenicRenault = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "Scénic" && v.Manufacturer!.Name == "Renault");
            var technoRenault = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Techno" && f.VehicleModel!.Name == "Scénic");

            var carClio = new Car
            {
                Year = 2022,
                Kilometer = 45000,
                Description = "Description Renault Clio à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = renault.Id,
                VehicleModelId = clioRenault.Id,
                FinitionId = intensRenault.Id,
            };
            context.Car.Add(carClio);
            await context.SaveChangesAsync();

            var repairCarClio = new CarRepair
            {
                RepairPrice = 1800,
                TypeOfRepair = "Réparation Renault Clio à compléter",
                CarId = carClio.Id
            };
            context.CarRepair.Add(repairCarClio);
            await context.SaveChangesAsync();

            var transactionCarClio = new CarTransaction
            {
                PurchaseDate = new DateOnly(2024, 2, 10),
                PurchasePrice = 10500,
                AvailabilityDate = new DateOnly(2024, 3, 5),
                CarId = carClio.Id
            };
            context.CarTransaction.Add(transactionCarClio);
            await context.SaveChangesAsync();

            var imageCarClio_1 = new CarImage { CarId = carClio.Id, IsCover = true, ImagePath = "/images/cars/clio 1.png" };
            var imageCarClio_2 = new CarImage { CarId = carClio.Id, IsCover = false, ImagePath = "/images/cars/clio 2.png" };
            var imageCarClio_3 = new CarImage { CarId = carClio.Id, IsCover = false, ImagePath = "/images/cars/clio 3.png" };
            context.CarImage.AddRange(imageCarClio_1, imageCarClio_2, imageCarClio_3);
            await context.SaveChangesAsync();

            var carScenic = new Car
            {
                Year = 2023,
                Kilometer = 30000,
                Description = "Description Renault Scénic à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = renault.Id,
                VehicleModelId = scenicRenault.Id,
                FinitionId = technoRenault.Id,
            };
            context.Car.Add(carScenic);
            await context.SaveChangesAsync();

            var repairCarScenic = new CarRepair
            {
                RepairPrice = 2200,
                TypeOfRepair = "Réparation Renault Scénic à compléter",
                CarId = carScenic.Id
            };
            context.CarRepair.Add(repairCarScenic);
            await context.SaveChangesAsync();

            var transactionCarScenic = new CarTransaction
            {
                PurchaseDate = new DateOnly(2024, 9, 1),
                PurchasePrice = 18000,
                AvailabilityDate = new DateOnly(2024, 10, 1),
                CarId = carScenic.Id
            };
            context.CarTransaction.Add(transactionCarScenic);
            await context.SaveChangesAsync();

            var imageCarScenic_1 = new CarImage { CarId = carScenic.Id, IsCover = true, ImagePath = "/images/cars/scenic 1.png" };
            var imageCarScenic_2 = new CarImage { CarId = carScenic.Id, IsCover = false, ImagePath = "/images/cars/scenic 2.png" };
            var imageCarScenic_3 = new CarImage { CarId = carScenic.Id, IsCover = false, ImagePath = "/images/cars/scenic 3.png" };
            context.CarImage.AddRange(imageCarScenic_1, imageCarScenic_2, imageCarScenic_3);
            await context.SaveChangesAsync();


            /////////////////////// PEUGEOT ///////////////////////
            var peugeot = context.Manufacturer.First(m => m.Name == "Peugeot");

            var troiscenthuitPeugeot = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "308" && v.Manufacturer!.Name == "Peugeot");
            var techEditionPeugeot = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Tech Edition" && f.VehicleModel!.Name == "308");

            var quatrecenthuitPeugeot = context.VehicleModel.Include(v => v.Manufacturer).First(v => v.Name == "408" && v.Manufacturer!.Name == "Peugeot");
            var allurePeugeot = context.Finition.Include(f => f.VehicleModel).First(f => f.Name == "Allure" && f.VehicleModel!.Name == "408");

            var car308 = new Car
            {
                Year = 2022,
                Kilometer = 38000,
                Description = "Description Peugeot 308 à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = peugeot.Id,
                VehicleModelId = troiscenthuitPeugeot.Id,
                FinitionId = techEditionPeugeot.Id,
            };
            context.Car.Add(car308);
            await context.SaveChangesAsync();

            var repairCar308 = new CarRepair
            {
                RepairPrice = 1200,
                TypeOfRepair = "Réparation Peugeot 308 à compléter",
                CarId = car308.Id
            };
            context.CarRepair.Add(repairCar308);
            await context.SaveChangesAsync();

            var transactionCar308 = new CarTransaction
            {
                PurchaseDate = new DateOnly(2024, 5, 12),
                PurchasePrice = 14000,
                AvailabilityDate = new DateOnly(2024, 6, 10),
                CarId = car308.Id
            };
            context.CarTransaction.Add(transactionCar308);
            await context.SaveChangesAsync();

            var imageCar308_1 = new CarImage { CarId = car308.Id, IsCover = true, ImagePath = "/images/cars/308 1.png" };
            var imageCar308_2 = new CarImage { CarId = car308.Id, IsCover = false, ImagePath = "/images/cars/308 2.png" };
            var imageCar308_3 = new CarImage { CarId = car308.Id, IsCover = false, ImagePath = "/images/cars/308 3.png" };
            context.CarImage.AddRange(imageCar308_1, imageCar308_2, imageCar308_3);
            await context.SaveChangesAsync();

            var car408 = new Car
            {
                Year = 2023,
                Kilometer = 22000,
                Description = "Description Peugeot 408 à compléter",
                Status = CarStatus.ForSale,
                ManufacturerId = peugeot.Id,
                VehicleModelId = quatrecenthuitPeugeot.Id,
                FinitionId = allurePeugeot.Id,
            };
            context.Car.Add(car408);
            await context.SaveChangesAsync();

            var repairCar408 = new CarRepair
            {
                RepairPrice = 900,
                TypeOfRepair = "Réparation Peugeot 408 à compléter",
                CarId = car408.Id
            };
            context.CarRepair.Add(repairCar408);
            await context.SaveChangesAsync();

            var transactionCar408 = new CarTransaction
            {
                PurchaseDate = new DateOnly(2025, 1, 5),
                PurchasePrice = 25000,
                AvailabilityDate = new DateOnly(2025, 2, 1),
                CarId = car408.Id
            };
            context.CarTransaction.Add(transactionCar408);
            await context.SaveChangesAsync();

            var imageCar408_1 = new CarImage { CarId = car408.Id, IsCover = true, ImagePath = "/images/cars/408 1.png" };
            var imageCar408_2 = new CarImage { CarId = car408.Id, IsCover = false, ImagePath = "/images/cars/408 2.png" };
            var imageCar408_3 = new CarImage { CarId = car408.Id, IsCover = false, ImagePath = "/images/cars/408 3.png" };
            context.CarImage.AddRange(imageCar408_1, imageCar408_2, imageCar408_3);
            await context.SaveChangesAsync();


        }



    }
}

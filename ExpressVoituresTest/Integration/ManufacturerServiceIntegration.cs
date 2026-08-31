using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresTest.IntegrationTests
{
    public class ManufacturerServiceIntegration
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IManufacturerService _manufacturerService;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IFinitionRepository _finitionRepository;
        private readonly IFinitionService _finitionService;

        public ManufacturerServiceIntegration()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=:memory:")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();

            _dbContext.Manufacturer.Add(new Manufacturer { Id = 1, Name = "Toyota" });
            _dbContext.SaveChanges();
            _dbContext.VehicleModel.Add(new VehicleModel { Id = 1, Name = "CHR", ManufacturerId = 1 });
            _dbContext.SaveChanges();
            _dbContext.Finition.Add(new Finition { Id = 1, Name = "Graphique", VehicleModelId = 1 });

            _manufacturerRepository = new ManufacturerRepository(_dbContext);
            _manufacturerService = new ManufacturerService(_manufacturerRepository);
            _vehicleModelRepository = new VehicleModelRepository(_dbContext);
            _vehicleModelService = new VehicleModelService(_vehicleModelRepository);
            _finitionRepository = new FinitionRepository(_dbContext);
            _finitionService = new FinitionService(_finitionRepository);
        }

        private async Task<List<Finition>> ListFinition(int id)
        {
            return await _finitionService.GetAllFinitionByVehicleModel(id);
        }

        private async Task<List<VehicleModel>> ListVehicleModel(int id)
        {
            return await _vehicleModelService.GetAllVehicleModelByManufacturer(id);
        }

        private async Task<List<Manufacturer>> ListManufacturer()
        {
            return await _manufacturerService.GetAllManufacturer();
        }


        [Fact]
        public async Task AddManufacturerTest()
        {
            // Arrange
            ManufacturerViewModel manufacturerViewModel = new ManufacturerViewModel { Name = "Test" };

            // Act
            await _manufacturerService.AddManufacturer(manufacturerViewModel);

            // Assert
            Assert.Equal(manufacturerViewModel.Id, (await ListManufacturer()).Last().Id);
        }

        [Fact]
        public async Task UpdateManufacturerTest()
        {
            // Arrange
            ManufacturerViewModel manufacturerViewModel = new ManufacturerViewModel { Name= "Test" };
            await _manufacturerService.AddManufacturer(manufacturerViewModel);

            // Act
            manufacturerViewModel.Name = "Test after update";
            await _manufacturerService.UpdateManufacturer(manufacturerViewModel);

            // Assert
            Assert.Equal("Test after update", (await ListManufacturer()).Last().Name);
        }

        [Fact]
        public async Task DeleteManufacturerTest()
        {
            // Arrange
            ManufacturerViewModel manufacturerViewModel = new ManufacturerViewModel { Name = "Test" };
            await _manufacturerService.AddManufacturer(manufacturerViewModel);
            VehicleModelViewModel vehicleModelViewModel = new VehicleModelViewModel { Name = "Test", ManufacturerId = manufacturerViewModel.Id };
            await _vehicleModelService.AddVehicleModel(vehicleModelViewModel);
            FinitionViewModel finitionNew1 = new FinitionViewModel { Name = "Test1", VehicleModelId = vehicleModelViewModel.Id };
            FinitionViewModel finitionNew2 = new FinitionViewModel { Name = "Test2", VehicleModelId = vehicleModelViewModel.Id };
            await _finitionService.AddFinition(finitionNew1);
            await _finitionService.AddFinition(finitionNew2);

            // Act
            await _manufacturerService.DeleteManufacturer(manufacturerViewModel.Id);
            List<Manufacturer> NewListManufacturers = await ListManufacturer();
            List<VehicleModel> NewListVehicleModel = await ListVehicleModel(manufacturerViewModel.Id);
            List<Finition> NewListFinition = await ListFinition(vehicleModelViewModel.Id);


            // Assert
            Assert.DoesNotContain(NewListManufacturers, i => i.Id == manufacturerViewModel.Id);
            Assert.DoesNotContain(NewListVehicleModel, i => i.Id == vehicleModelViewModel.Id);
            Assert.DoesNotContain(NewListFinition, i => i.Id == finitionNew1.Id);
            Assert.DoesNotContain(NewListFinition, i => i.Id == finitionNew2.Id);

        }

    }
}

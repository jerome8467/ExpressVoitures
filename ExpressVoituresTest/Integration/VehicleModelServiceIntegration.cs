using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresTest.IntegrationTests
{
    public class VehicleModelServiceIntegration
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IFinitionRepository _finitionRepository;
        private readonly IFinitionService _finitionService;

        public VehicleModelServiceIntegration()
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
            _vehicleModelRepository = new VehicleModelRepository(_dbContext);
            _vehicleModelService = new VehicleModelService(_vehicleModelRepository);
            _finitionRepository = new FinitionRepository(_dbContext);
            _finitionService = new FinitionService(_finitionRepository);
        }

        private async Task<int> ManufacturerFirstId()
        {
            Manufacturer manufacturer = (await _manufacturerRepository.GetAllManufacturer()).First();
            return manufacturer.Id;
        }

        private async Task<List<Finition>> ListFinition(int id)
        {
            return await _finitionService.GetAllFinitionByVehicleModel(id);
        }

        private async Task<List<VehicleModel>> ListVehicleModel(int id)
        {
            return await _vehicleModelService.GetAllVehicleModelByManufacturer(id);
        }


        [Fact]
        public async Task AddVehicleModelTest()
        {
            // Arrange
            VehicleModelViewModel vehicleModelViewModelNew = new VehicleModelViewModel { Name = "Test", ManufacturerId = await ManufacturerFirstId() };

            // Act
            await _vehicleModelService.AddVehicleModel(vehicleModelViewModelNew);

            // Assert
            Assert.Equal(vehicleModelViewModelNew.Id, (await ListVehicleModel(vehicleModelViewModelNew.ManufacturerId)).Last().Id);
        }

        [Fact]
        public async Task UpdateVehicleModelTest()
        {
            // Arrange
            VehicleModelViewModel vehicleModelViewModelNew = new VehicleModelViewModel { Name = "Test", ManufacturerId = await ManufacturerFirstId() };
            await _vehicleModelService.AddVehicleModel(vehicleModelViewModelNew);

            // Act
            vehicleModelViewModelNew.Name = "Test after update";
            await _vehicleModelService.UpdateVehicleModel(vehicleModelViewModelNew);

            // Assert
            Assert.Equal("Test after update", (await ListVehicleModel(vehicleModelViewModelNew.ManufacturerId)).Last().Name);

        }

        [Fact]
        public async Task DeleteVehicleModel()
        {
            // Arrange
            VehicleModelViewModel vehicleModelViewModel = new VehicleModelViewModel { Name = "Test", ManufacturerId = await ManufacturerFirstId() };
            await _vehicleModelService.AddVehicleModel(vehicleModelViewModel);
            FinitionViewModel finitionNew1 = new FinitionViewModel { Name = "Test1", VehicleModelId = vehicleModelViewModel.Id };
            FinitionViewModel finitionNew2 = new FinitionViewModel { Name = "Test2", VehicleModelId = vehicleModelViewModel.Id };
            await _finitionService.AddFinition(finitionNew1);
            await _finitionService.AddFinition(finitionNew2);

            // Act
            await _vehicleModelService.DeleteVehicleModel(vehicleModelViewModel.Id);
            List<VehicleModel> NewListVehicleModel = await ListVehicleModel(vehicleModelViewModel.ManufacturerId);
            List<Finition> NewListFinition = await ListFinition(vehicleModelViewModel.Id);

            // Assert
            Assert.DoesNotContain(NewListVehicleModel, i => i.Id == vehicleModelViewModel.Id);
            Assert.DoesNotContain(NewListFinition, i => i.Id == finitionNew1.Id);
            Assert.DoesNotContain(NewListFinition, i => i.Id == finitionNew2.Id);

        }

    }
}

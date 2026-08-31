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
    public class FinitionServiceIntegration
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IFinitionRepository _finitionRepository;
        private readonly IFinitionService _finitionService;

        public FinitionServiceIntegration()
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

            _vehicleModelRepository = new VehicleModelRepository(_dbContext);
            _finitionRepository = new FinitionRepository(_dbContext);
            _finitionService = new FinitionService(_finitionRepository);
        }
        private async Task<int> VehicleModelFirstId()
        {
            VehicleModel vehicleModel = (await _vehicleModelRepository.GetAllVehicleModel()).First();
            return vehicleModel.Id;
        }

        private async Task<List<Finition>> ListFinition(int id)
        {
            return await _finitionService.GetAllFinitionByVehicleModel(id);
        }

        


        [Fact]
        public async Task AddFinitionTest()
        {
            // Arrange
            FinitionViewModel finitionNew = new FinitionViewModel { Name = "Test", VehicleModelId = await VehicleModelFirstId() };

            // Act
            await _finitionService.AddFinition(finitionNew);

            // Assert
            Assert.Equal(finitionNew.Id, (await ListFinition(finitionNew.VehicleModelId)).Last().Id);
        }

        [Fact]
        public async Task UpdateFinitionTest()
        {
            // Arrange
            FinitionViewModel finitionNew = new FinitionViewModel { Name = "Test", VehicleModelId = await VehicleModelFirstId() };
            await _finitionService.AddFinition(finitionNew);

            // Act
            finitionNew.Name = "Test after update";
            await _finitionService.UpdateFinition(finitionNew);

            // Assert
            Assert.Equal("Test after update", (await ListFinition(finitionNew.VehicleModelId)).Last().Name);
        }

        [Fact]
        public async Task DeleteFinitionTest()
        {
            // Arrange
            FinitionViewModel finitionNew1 = new FinitionViewModel { Name = "Test1", VehicleModelId = await VehicleModelFirstId() };
            FinitionViewModel finitionNew2 = new FinitionViewModel { Name = "Test2", VehicleModelId = await VehicleModelFirstId() };
            FinitionViewModel finitionNew3 = new FinitionViewModel { Name = "Test3", VehicleModelId = await VehicleModelFirstId() };
            await _finitionService.AddFinition(finitionNew1);
            await _finitionService.AddFinition(finitionNew2);
            await _finitionService.AddFinition(finitionNew3);

            // Act
            await _finitionService.DeleteFinition(finitionNew2.Id);

            // Assert
            Assert.DoesNotContain(await _finitionService.GetAllFinition(),i => i.Id == finitionNew2.Id);
        }


    }
}
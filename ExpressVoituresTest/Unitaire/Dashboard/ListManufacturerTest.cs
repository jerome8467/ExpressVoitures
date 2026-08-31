using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;
using Moq;
using Xunit;

namespace ExpressVoituresTest.Unitaire.Dashboard
{
    public class ManufacturerDashboardTest
    {
        private readonly Mock<IManufacturerRepository> _mockManufacturerRepository;
        private readonly ManufacturerService _manufacturerService;
        private readonly List<Manufacturer> _manufacturers;

        public ManufacturerDashboardTest()
        {
            _mockManufacturerRepository = new Mock<IManufacturerRepository>();

            _manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "Toyota",
                    VehicleModel = new List<VehicleModel>
                    {
                        new VehicleModel { Id = 1, Name = "CHR", Finition = new List<Finition> { new Finition { Id = 1, Name = "Graphite" }, new Finition { Id = 2, Name = "Dynamic" }, new Finition { Id = 3, Name = "Collection" } } },
                        new VehicleModel { Id = 2, Name = "Yaris", Finition = new List<Finition> { new Finition { Id = 4, Name = "Base" }, new Finition { Id = 5, Name = "GR" } } }
                    }
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Renault",
                    VehicleModel = new List<VehicleModel>
                    {
                        new VehicleModel { Id = 3, Name = "Clio", Finition = new List<Finition> { new Finition { Id = 6, Name = "Zen" } } }
                    }
                }
            };

            _mockManufacturerRepository.Setup(r => r.GetAllManufacturerWithInclude()).ReturnsAsync(_manufacturers);
            _manufacturerService = new ManufacturerService(_mockManufacturerRepository.Object);
        }


        [Fact]
        public async Task ManufacturerCount()
        {
            // Arrange
            List<ManufacturerDashboardViewModel> manufacturerList = await _manufacturerService.GetAllManufacturerForDashboard();

            // Act
            ManufacturerDashboardViewModel? toyota = manufacturerList.FirstOrDefault(i => i.Id == 1);
            ManufacturerDashboardViewModel? renault = manufacturerList.FirstOrDefault(i => i.Id == 2);

            // Assert
            Assert.Equal(2, toyota?.CountVehicleModel);
            Assert.Equal(5, toyota?.CountFinition);
            Assert.Equal(1, renault?.CountVehicleModel);
            Assert.Equal(1, renault?.CountFinition);
        }

    }
}
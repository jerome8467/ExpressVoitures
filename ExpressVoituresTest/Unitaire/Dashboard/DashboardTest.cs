using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Services;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Xunit;

namespace ExpressVoituresTest.Unitaire.Dashboard
{
    public class DashboardTest
    {
        private readonly Mock<ICarService>? _mockCarService;
        private readonly Mock<IManufacturerService> _mockManufacturerService;
        private readonly DashboardService? _dashboardService;
        private readonly List<CarAdminViewModel>? _cars;

        public DashboardTest()
        {
            _mockCarService = new Mock<ICarService>();
            _mockManufacturerService = new Mock<IManufacturerService>();

            _cars = new List<CarAdminViewModel>
            {
                new CarAdminViewModel { Status = CarStatus.Sold, RepairPrice = "1000", PurchasePrice = "5000", AdditionalAmount = 500, PurchaseDate = new DateOnly(2025, 1, 1), SaleDate = new DateOnly(2025, 1, 7) },
                new CarAdminViewModel { Status = CarStatus.Sold, RepairPrice = "2000", PurchasePrice = "6000", AdditionalAmount = 500, PurchaseDate = new DateOnly(2025, 2, 1), SaleDate = new DateOnly(2025, 2, 10) },
                new CarAdminViewModel { Status = CarStatus.Sold, RepairPrice = "3000", PurchasePrice = "7000", AdditionalAmount = 500, PurchaseDate = new DateOnly(2025, 3, 1), SaleDate = new DateOnly(2025, 3, 16) },
                new CarAdminViewModel { Status = CarStatus.ForSale, RepairPrice = "4000", PurchasePrice = "8000", AdditionalAmount = 500, PurchaseDate = new DateOnly(2025, 7, 1), SaleDate = null },
                new CarAdminViewModel { Status = CarStatus.InRepair, RepairPrice = "5000", PurchasePrice = "9000", AdditionalAmount = 500, PurchaseDate = new DateOnly(2025, 9, 1), SaleDate = null }
            };

            _mockCarService.Setup(s => s.GetAllCarAdminViewModel()).ReturnsAsync(_cars);
            _dashboardService = new DashboardService(_mockCarService.Object, _mockManufacturerService.Object);
        }

        [Fact]
        public async Task ResultDashboard()
        {
            // Arrange
            DashboardViewModel dashboardViewModel = await _dashboardService!.FulldashboardViewModel();

            // Assert
            Assert.Equal(3000, dashboardViewModel.AverageRepairCost);
            Assert.Equal(3, dashboardViewModel.CarsSold);
            Assert.Equal(1, dashboardViewModel.CarsForSale);
            Assert.Equal(1, dashboardViewModel.CarsInRepair);
            Assert.Equal(10, dashboardViewModel.AverageDaysBeforeSale);
            Assert.Equal(25500, dashboardViewModel.TotalRevenue);
        }



    }
}

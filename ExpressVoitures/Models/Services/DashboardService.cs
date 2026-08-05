using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;

namespace ExpressVoitures.Models.Services
{
    public class DashboardService : IDashboardService
    {

        private readonly ICarService _carService;
        private readonly IManufacturerService _manufacturerService;

        public DashboardService(ICarService carService, IManufacturerService manufacturerService)
        {
            _carService = carService;
            _manufacturerService = manufacturerService;
        }

        public async Task<DashboardViewModel> FulldashboardViewModel()
        {
            IEnumerable<CarAdminViewModel> listCarAdminViewModel = await _carService.GetAllCarAdminViewModel();
            IEnumerable<ManufacturerDashboardViewModel> manufacturerDashboardViewModels = await _manufacturerService.GetAllManufacturerForDashboard();

            DashboardViewModel dashboardViewModel = new DashboardViewModel
            {
                CarAdminViewModels = listCarAdminViewModel,
                ManufacturerDashboardViewModelList = manufacturerDashboardViewModels,
                AverageRepairCost = GetAverageRepairCost(listCarAdminViewModel),
                CarsInRepair = GetTotalCarsInRepair(listCarAdminViewModel),
                CarsForSale = GetTotalCarsForSale(listCarAdminViewModel),
                CarsSold = GetTotalCarsSold(listCarAdminViewModel),
                TotalRevenue = GetTotalRevenue(listCarAdminViewModel),
                AverageDaysBeforeSale = GetAverageDaysBeforeSale(listCarAdminViewModel)
            };

            return dashboardViewModel;

        }

        private double GetAverageRepairCost(IEnumerable<CarAdminViewModel> carAdminViewModel)
        {
            double totalRepair = carAdminViewModel.Sum(r => double.Parse(r.RepairPrice));
            int count = carAdminViewModel.Count();
            double result = 0;
            if (count > 0) { result = Math.Round(totalRepair / count , 2); }
            return result;
        }

        private int GetTotalCarsInRepair(IEnumerable<CarAdminViewModel> carAdminViewModel)
        {
            int count = carAdminViewModel.Count(s => s.Status == CarStatus.InRepair);
            return count;
        }

        private int GetTotalCarsForSale(IEnumerable<CarAdminViewModel> carAdminViewModel)
        {
            int count = carAdminViewModel.Count(s => s.Status == CarStatus.ForSale);
            return count;
        }
        private int GetTotalCarsSold(IEnumerable<CarAdminViewModel> carAdminViewModel)
        {
            int count = carAdminViewModel.Count(s => s.Status == CarStatus.Sold);
            return count;
        }
        private double GetTotalRevenue(IEnumerable<CarAdminViewModel> carAdminViewModel)
        {
            
            IEnumerable<CarAdminViewModel> sortedList = carAdminViewModel.Where(s => s.Status == CarStatus.Sold);
            double totalRepair = sortedList.Sum(r => double.Parse(r.RepairPrice));
            double totalTransaction = sortedList.Sum(p => double.Parse(p.PurchasePrice));
            double additionnalAmount = sortedList.Sum(a => a.AdditionalAmount);
            double totalRevenue = totalRepair + totalTransaction + additionnalAmount;

            return totalRevenue;
        }
        private double GetAverageDaysBeforeSale(IEnumerable<CarAdminViewModel> carAdminViewModel)
        {
            IEnumerable<CarAdminViewModel> soldCars = carAdminViewModel
            .Where(s => s.Status == CarStatus.Sold && s.SaleDate.HasValue && s.PurchaseDate.HasValue);

            int count = soldCars.Count();

            if (count == 0) return 0;

            double totalDay = 0;
            foreach (var day in soldCars)
            {
                totalDay += day.SaleDate!.Value.DayNumber - day.PurchaseDate!.Value.DayNumber; 
            }

            totalDay = totalDay / count;
            return totalDay;

        }



    }
}

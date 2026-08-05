using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;

namespace ExpressVoitures.Models.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<CarAdminViewModel>? CarAdminViewModels { get; set; }
        public IEnumerable<ManufacturerDashboardViewModel>? ManufacturerDashboardViewModelList { get; set; }
        public double AverageRepairCost { get; set; }
        public int CarsInRepair {  get; set; }
        public int CarsForSale { get; set; }
        public int CarsSold { get; set; }
        public double TotalRevenue {  get; set; }
        public double AverageDaysBeforeSale { get; set; }

    }
}

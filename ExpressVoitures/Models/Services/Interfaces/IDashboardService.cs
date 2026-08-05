using ExpressVoitures.Models.ViewModels;

namespace ExpressVoitures.Models.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> FulldashboardViewModel();

    }
}

using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services.Interfaces
{
    public interface IFinitionService
    {
        public Task<List<Finition>> GetAllFinitionByVehicleModel(int vehicleModelId);
        public Task<List<Finition>> GetAllFinition();
        public Task<List<FinitionViewModel>> GetAllFinitionViewModelByVehicleModel(int vehicleModelId);
        public Task<FinitionViewModel?> GetByIdFinitionViewModel(FinitionViewModel finitionView);
        public Task<List<ValidationResult>> AddFinition(FinitionViewModel finitionNew);
        public Task<List<ValidationResult>> UpdateFinition(FinitionViewModel finitionUpdate);
        public Task DeleteFinition(int id);
    }
}

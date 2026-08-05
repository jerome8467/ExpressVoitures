using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services.Interfaces
{
    public interface IVehicleModelService
    {
        public Task<List<VehicleModel>> GetAllVehicleModelByManufacturer(int manufacturerId);
        public Task<List<VehicleModel>> GetAllVehicleModel();
        public Task<List<VehicleModelViewModel>> GetAllVehicleModelViewModelByManufacturer(int manufacturerId);
        public Task<VehicleModelViewModel?> GetByIdVehicleModelViewModel(VehicleModelViewModel vehicleModelView);
        public Task<List<ValidationResult>> AddVehicleModel(VehicleModelViewModel vehicleModelNew);
        public Task<List<ValidationResult>> UpdateVehicleModel(VehicleModelViewModel vehicleModelUpdate);
        public Task DeleteVehicleModel(int id);
    }
}

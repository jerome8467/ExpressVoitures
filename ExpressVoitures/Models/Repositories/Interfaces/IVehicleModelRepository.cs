using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface IVehicleModelRepository
    {
        public Task<IEnumerable<VehicleModel>> GetAllVehicleModelByManufacturer(int manufacturerId);
        public Task<IEnumerable<VehicleModel>> GetAllVehicleModel();
        public Task<VehicleModel?> GetByIdVehicleModel(int id);
        public Task AddVehicleModel(VehicleModel vehicleModelNew);
        public Task UpdateVehicleModel(VehicleModel vehicleModelUpdate);
        public Task DeleteVehicleModel(int id);
    }
}

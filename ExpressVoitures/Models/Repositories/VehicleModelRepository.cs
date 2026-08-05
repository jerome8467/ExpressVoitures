using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private ApplicationDbContext _dataBase;
        public VehicleModelRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModel(int manufacturerId)
        {
            IEnumerable<VehicleModel> vehicleModelList = await _dataBase.VehicleModel.Where(i => i.ManufacturerId == manufacturerId)
                .Include(m => m.Manufacturer)
                .ToListAsync();
            return vehicleModelList;
        }

        public async Task<VehicleModel?> GetByIdVehicleModel(int id)
        {
            VehicleModel? vehicleModelById = await _dataBase.VehicleModel
                .Include(m => m.Manufacturer)
                .FirstOrDefaultAsync(v => v.Id == id);
            return vehicleModelById;
        }

        public async Task AddVehicleModel(VehicleModel vehicleModelNew)
        {
            _dataBase.VehicleModel.Add(vehicleModelNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateVehicleModel(VehicleModel vehicleModelUpdate)
        {
            VehicleModel? vehicleModelCurrent = await _dataBase.VehicleModel.FirstOrDefaultAsync(v => v.Id == vehicleModelUpdate.Id);
            if (vehicleModelCurrent != null)
            {
                _dataBase.VehicleModel.Update(vehicleModelUpdate);
                await _dataBase.SaveChangesAsync();
            }
        }

        public async Task DeleteVehicleModel(int id)
        {
            VehicleModel? vehicleModel = await _dataBase.VehicleModel.FirstOrDefaultAsync(v => v.Id==id);
            if (vehicleModel != null)
            {
                _dataBase.VehicleModel.Remove(vehicleModel);
                await _dataBase.SaveChangesAsync();
            }
        }
    }
}

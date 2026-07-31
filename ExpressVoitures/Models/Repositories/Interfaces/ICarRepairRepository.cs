using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarRepairRepository
    {
        public Task<IEnumerable<CarRepair>> GetAllCarRepair();
        public Task<CarRepair?> GetByIdCarRepair(int id);
        public Task<CarRepair?> GetCarRepairByIdCar(int carId);
        public Task AddCarRepair(CarRepair carRepairNew);
        public Task UpdateCarRepair(CarRepair carRepairUpdate);
        public Task DeleteCarRepair(int id);
    }
}

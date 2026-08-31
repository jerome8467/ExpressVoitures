using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarRepairRepository
    {
        public Task<IEnumerable<CarRepair>> GetAllCarRepair();
        public Task AddCarRepair(CarRepair carRepairNew);
        public Task<CarRepair?> GetCarRepairByID(int id);

    }
}

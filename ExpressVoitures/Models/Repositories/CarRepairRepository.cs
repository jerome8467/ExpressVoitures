using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class CarRepairRepository : ICarRepairRepository
    {
        private ApplicationDbContext _dataBase;
        public CarRepairRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<CarRepair>> GetAllCarRepair()
        {
            IEnumerable<CarRepair> carRepairList = await _dataBase.CarRepair
                .Include(c => c.Car)
                .ToListAsync();
            return carRepairList;
        }

        public async Task AddCarRepair(CarRepair carRepairNew)
        {
            _dataBase.CarRepair.Add(carRepairNew);
            await _dataBase.SaveChangesAsync();
        }


    }
}

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

        public async Task<CarRepair?> GetByIdCarRepair(int id)
        {
            CarRepair? carRepairById = await _dataBase.CarRepair
                .Include(c => c.Car)
                .FirstOrDefaultAsync(f => f.Id == id);
            return carRepairById;
        }

        public async Task<CarRepair?> GetCarRepairByIdCar(int carId)
        {
            CarRepair? carRepairByCarId = await _dataBase.CarRepair
                .Include(c => c.Car)
                .FirstOrDefaultAsync(f => f.CarId == carId);
            return carRepairByCarId;
        }

        public async Task AddCarRepair(CarRepair carRepairNew)
        {
            _dataBase.CarRepair.Add(carRepairNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateCarRepair(CarRepair carRepairUpdate)
        {
            CarRepair? carRepairCurrent = await _dataBase.CarRepair.FirstOrDefaultAsync(f => f.Id == carRepairUpdate.Id);
            if (carRepairCurrent != null)
            {
                _dataBase.CarRepair.Update(carRepairUpdate);
                await _dataBase.SaveChangesAsync();
            }
        }

        public async Task DeleteCarRepair(int id)
        {
            CarRepair? carRepair = await _dataBase.CarRepair.FirstOrDefaultAsync(f => f.Id == id);
            if (carRepair != null)
            {
                _dataBase.CarRepair.Remove(carRepair);
                await _dataBase.SaveChangesAsync();
            }
        }

    }
}

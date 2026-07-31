using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class CarRepository : ICarRepository
    {
        private ApplicationDbContext _dataBase;

        public CarRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<Car>> GetAllCar()
        {
            IEnumerable<Car> carList = await _dataBase.Car
                .Include(m => m.Manufacturer)
                .Include(v => v.VehicleModel)
                .Include(f => f.Finition)
                .Include(r => r.CarRepair)
                .Include(t => t.CarTransaction)
                .Include(i => i.CarImage)
                .ToListAsync();
            return carList;
        }

        public async Task<Car?> GetByIdCar(int id)
        {
            Car? carById = await _dataBase.Car
                .Include(m => m.Manufacturer)
                .Include(v => v.VehicleModel)
                .Include(f => f.Finition)
                .Include(r => r.CarRepair)
                .Include(t => t.CarTransaction)
                .Include(i => i.CarImage)
                .FirstOrDefaultAsync(c => c.Id == id);
            return carById;
        }

        public async Task AddCar(Car carNew) 
        {
            _dataBase.Car.Add(carNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateCar(Car carUpdate)
        {
            Car? carCurrent = await _dataBase.Car.FirstOrDefaultAsync(c =>c.Id == carUpdate.Id);
            if (carCurrent != null)
            {
                _dataBase.Car.Update(carUpdate);
                await _dataBase.SaveChangesAsync();
            }
        }

        public async Task DeleteCar(int id)
        {
            Car? car = await _dataBase.Car.SingleOrDefaultAsync(c => c.Id ==id);
            if (car != null)
            {
                _dataBase.Car.Remove(car);
                await _dataBase.SaveChangesAsync();
            }
        }


    }
}

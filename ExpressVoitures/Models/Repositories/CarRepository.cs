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
                .Include(i => i.CarImage!.Where(img => img.IsCover).Take(1))
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
                .Include(i => i.CarImage).AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == id);
            return carById;
        }

        public async Task AddCar(Car carNew) 
        {
            _dataBase.Car.Add(carNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car, CarRepair carRepair, CarTransaction carTransaction)
        {
            Car? carCurrent = await GetByIdCar(car.Id);

            if (carCurrent == null) return;
                _dataBase.Car.Update(car);

            if (carCurrent.CarRepair == null) return; 
                _dataBase.CarRepair.Update(carRepair);

            if (carCurrent.CarTransaction == null) return;
                _dataBase.CarTransaction.Update(carTransaction);

            await _dataBase.SaveChangesAsync();

            //Cas d'exemple pour des colonnes potentiellement absente du ViewModel à ne pas modifier
            /*
            _dataBase.Entry(car).Property(c => c.Colonne7).IsModified = false;
            _dataBase.Entry(carRepair).Property(c => c.Colonne4).IsModified = false;
            _dataBase.Entry(carTransaction).Property(c => c.Colonne5).IsModified = false;
            */
        }

        public async Task DeleteCar(int id)
        {
            Car? car = await _dataBase.Car.SingleOrDefaultAsync(c => c.Id ==id);
            if (car == null) return;
                _dataBase.Car.Remove(car);
                await _dataBase.SaveChangesAsync();
        }


    }
}

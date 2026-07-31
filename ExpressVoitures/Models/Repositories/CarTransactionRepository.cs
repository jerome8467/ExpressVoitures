using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ExpressVoitures.Models.Repositories
{
    public class CarTransactionRepository : ICarTransactionRepository
    {
        private ApplicationDbContext _dataBase;
        public CarTransactionRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<CarTransaction>> GetAllCarTransaction()
        {
            IEnumerable<CarTransaction> carTransactionList = await _dataBase.CarTransaction
                .Include(c => c.Car)
                .ToListAsync();
            return carTransactionList;
        }

        public async Task<CarTransaction?> GetByIdCarTransaction(int id)
        {
            CarTransaction? carTransactionById = await _dataBase.CarTransaction
                .Include(c => c.Car)
                .FirstOrDefaultAsync(f => f.Id == id);
            return carTransactionById;
        }

        public async Task<CarTransaction?> GetCarTransactionByIdCar(int carId)
        {
            CarTransaction? carTransactionByCarId = await _dataBase.CarTransaction
                .Include(c => c.Car)
                .FirstOrDefaultAsync(f => f.CarId == carId);
            return carTransactionByCarId;
        }

        public async Task AddCarTransaction(CarTransaction carTransactionNew)
        {
            _dataBase.CarTransaction.Add(carTransactionNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateCarTransaction(CarTransaction carTransactionUpdate)
        {
            CarTransaction? carTransactionCurrent = await _dataBase.CarTransaction.FirstOrDefaultAsync(f => f.Id == carTransactionUpdate.Id);
            if (carTransactionCurrent != null)
            {
                _dataBase.CarTransaction.Update(carTransactionUpdate);
                await _dataBase.SaveChangesAsync();
            }
        }

        public async Task DeleteCarTransaction(int id)
        {
            CarTransaction? carTransaction = await _dataBase.CarTransaction.FirstOrDefaultAsync(f => f.Id == id);
            if (carTransaction != null)
            {
                _dataBase.CarTransaction.Remove(carTransaction);
                await _dataBase.SaveChangesAsync();
            }
        }
    }
}

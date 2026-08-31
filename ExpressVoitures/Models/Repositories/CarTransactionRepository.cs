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
                /*.Include(c => c.Car)*/
                .ToListAsync();
            return carTransactionList;
        }

        public async Task AddCarTransaction(CarTransaction carTransactionNew)
        {
            _dataBase.CarTransaction.Add(carTransactionNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task<CarTransaction?> GetCarTransactionById(int id)
        {
            CarTransaction? carTransaction = await _dataBase.CarTransaction.FirstOrDefaultAsync(i => i.Id == id);
            return carTransaction;
        }

    }
}

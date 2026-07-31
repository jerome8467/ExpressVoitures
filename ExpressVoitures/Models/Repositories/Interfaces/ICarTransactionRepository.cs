using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarTransactionRepository
    {
        public Task<IEnumerable<CarTransaction>> GetAllCarTransaction();
        public Task<CarTransaction?> GetByIdCarTransaction(int id);
        public Task<CarTransaction?> GetCarTransactionByIdCar(int carId);
        public Task AddCarTransaction(CarTransaction carTransactionNew);
        public Task UpdateCarTransaction(CarTransaction carTransactionUpdate);
        public Task DeleteCarTransaction(int id);
    }
}

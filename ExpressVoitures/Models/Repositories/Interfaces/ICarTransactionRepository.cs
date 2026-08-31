using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarTransactionRepository
    {
        public Task<IEnumerable<CarTransaction>> GetAllCarTransaction();
        public Task AddCarTransaction(CarTransaction carTransactionNew);
        public Task<CarTransaction?> GetCarTransactionById(int id);

    }
}

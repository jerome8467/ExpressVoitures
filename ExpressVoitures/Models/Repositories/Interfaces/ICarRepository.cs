using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<IEnumerable<Car>> GetAllCar();
        public Task<Car?> GetByIdCar(int id);
        public Task AddCar(Car carNew);
        public Task UpdateCar(Car carUpdate);
        public Task DeleteCar(int id);

    }
}

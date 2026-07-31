using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarImageRepository
    {
        public Task<IEnumerable<CarImage>> GetAllCarImage(int carId);
        public Task<CarImage?> GetByIdCarImage(int id);
        public Task AddCarImage(CarImage carImageNew);
        public Task UpdateCarImage(CarImage carImageUpdate);
        public Task DeleteCarImage(int id);
    }
}

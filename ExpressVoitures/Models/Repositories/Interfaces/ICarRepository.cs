using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        void SaveCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
        Car GetCarById(int id);
    }
}

using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Services.Interfaces

    //test
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        void SaveCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
        Car GetCarById(int id);
    }
}

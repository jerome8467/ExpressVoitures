using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;

namespace ExpressVoitures.Models.Repositories
{
    public class CarRepository : ICarRepository
    {

        public IEnumerable<Car> GetAllCars()
        {
            //Contenu a modifier
            var tempolistcar = new List<Car>();
            return tempolistcar;
        }

        public void SaveCar(Car car) 
        {
            
        }

        public void UpdateCar(Car car)
        {

        }

        public void DeleteCar(int id)
        {

        }

        public Car GetCarById(int id) 
        {
            //Contenu a modifier
            var car = new Car();
            return car;
        }


    }
}

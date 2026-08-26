using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class CarImageRepository : ICarImageRepository
    {
        private ApplicationDbContext _dataBase;
        public CarImageRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<CarImage>> GetAllCarImage(int carId)
        {
            IEnumerable<CarImage> carImageList = await _dataBase.CarImage
                .Include(c => c.Car)
                .Where(i => i.CarId == carId)
                .ToListAsync();
            return carImageList;
        }

        public async Task<CarImage?> GetByIdCarImage(int id)
        {
            CarImage? carImageById = await _dataBase.CarImage
                .Include(c => c.Car)
                .FirstOrDefaultAsync(f => f.Id == id);
            return carImageById;
        }

        public async Task AddCarImage(CarImage carImageNew)
        {
            _dataBase.CarImage.Add(carImageNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateCarImage(CarImage carImageUpdate)
        {
            CarImage? carImageCurrent = await _dataBase.CarImage.FirstOrDefaultAsync(f => f.Id == carImageUpdate.Id);
            if (carImageCurrent == null) return;
            _dataBase.CarImage.Update(carImageUpdate);
            await _dataBase.SaveChangesAsync();
        }

        public async Task DeleteCarImage(int id)
        {
            CarImage? carImage = await _dataBase.CarImage.FirstOrDefaultAsync(f => f.Id == id);
            if (carImage == null) return;
                _dataBase.CarImage.Remove(carImage);
                await _dataBase.SaveChangesAsync();
        }
    }
}

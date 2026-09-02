using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class CarRepairRepository : ICarRepairRepository
    {
        private ApplicationDbContext _dataBase;
        public CarRepairRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<CarRepair>> GetAllCarRepair()
        {
            IEnumerable<CarRepair> carRepairList = await _dataBase.CarRepair
                .ToListAsync();
            return carRepairList;
        }

        public async Task AddCarRepair(CarRepair carRepairNew)
        {
            _dataBase.CarRepair.Add(carRepairNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task<CarRepair?> GetCarRepairByID(int id)
        {
            CarRepair? carRepair = await _dataBase.CarRepair.FirstOrDefaultAsync(i => i.Id == id);

            return carRepair;
        }


    }
}

using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {

        private ApplicationDbContext _dataBase;
        public ManufacturerRepository (ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturer()
        {
            IEnumerable<Manufacturer> manufacturerList = await _dataBase.Manufacturer.ToListAsync();
            return manufacturerList;
        }
        public async Task<IEnumerable<Manufacturer>> GetAllManufacturerWithInclude()
        {
            IEnumerable<Manufacturer> manufacturerList =
                await _dataBase.Manufacturer
                .Include(m => m.VehicleModel)
                    .ThenInclude(v => v.Finition)
                .ToListAsync();
            return manufacturerList;
        }

        public async Task<Manufacturer?> GetByIdManufacturer(int id)
        {
            Manufacturer? manufacturerById = await _dataBase.Manufacturer.FirstOrDefaultAsync(m => m.Id == id);
            return manufacturerById;
        }

        public async Task AddManufacturer(Manufacturer manufacturerNew)
        {
            _dataBase.Manufacturer.Add(manufacturerNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateManufacturer(Manufacturer manufacturerUpdate)
        {
            Manufacturer? manufacturerCurrent = await _dataBase.Manufacturer.FirstOrDefaultAsync(m => m.Id == manufacturerUpdate.Id);
            if (manufacturerCurrent == null) return;
                manufacturerCurrent.Name = manufacturerUpdate.Name;
                await _dataBase.SaveChangesAsync();
        }

        public async Task DeleteManufacturer(int id)
        {
            Manufacturer? manufacturer = await _dataBase.Manufacturer.FirstOrDefaultAsync(m => m.Id == id);
            if(manufacturer == null) return;
                _dataBase.Manufacturer.Remove(manufacturer);
                await _dataBase.SaveChangesAsync();
        }
    }
}

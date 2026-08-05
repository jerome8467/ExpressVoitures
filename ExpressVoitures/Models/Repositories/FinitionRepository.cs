using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class FinitionRepository : IFinitionRepository
    {
        private ApplicationDbContext _dataBase;
        public FinitionRepository(ApplicationDbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IEnumerable<Finition>> GetAllFinition(int vehicleModelId)
        {
            IEnumerable<Finition> finitionList = await _dataBase.Finition.Where(v => v.VehicleModelId == vehicleModelId)
                .Include(v => v.VehicleModel)
                .ToListAsync();
            return finitionList;
        }

        public async Task<Finition?> GetByIdFinition(int id)
        {
            Finition? finitionById = await _dataBase.Finition
                .Include(v => v.VehicleModel)
                .FirstOrDefaultAsync(f => f.Id == id);
            return finitionById;
        }

        public async Task AddFinition(Finition finitionNew)
        {
            _dataBase.Finition.Add(finitionNew);
            await _dataBase.SaveChangesAsync();
        }

        public async Task UpdateFinition(Finition finitionUpdate)
        {
            Finition? finitionCurrent = await _dataBase.Finition.FirstOrDefaultAsync(f => f.Id == finitionUpdate.Id);
            if (finitionCurrent != null)
            {
                _dataBase.Finition.Update(finitionUpdate);
                await _dataBase.SaveChangesAsync();
            }
        }

        public async Task DeleteFinition(int id)
        {
            Finition? finition = await _dataBase.Finition.FirstOrDefaultAsync(f => f.Id == id);
            if (finition != null)
            {
                _dataBase.Finition.Remove(finition);
                await _dataBase.SaveChangesAsync();
            }
        }
    }
}

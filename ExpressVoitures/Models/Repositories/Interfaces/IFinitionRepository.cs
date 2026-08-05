using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface IFinitionRepository
    {
        public Task<IEnumerable<Finition>> GetAllFinition(int vehicleModelId);
        public Task<Finition?> GetByIdFinition(int id);
        public Task AddFinition(Finition finitionNew);
        public Task UpdateFinition(Finition finitionUpdate);
        public Task DeleteFinition(int id);
    }
}

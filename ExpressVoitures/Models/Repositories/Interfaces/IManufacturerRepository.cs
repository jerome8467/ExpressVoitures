using ExpressVoitures.Models.Entities;

namespace ExpressVoitures.Models.Repositories.Interfaces
{
    public interface IManufacturerRepository
    {
        public Task<IEnumerable<Manufacturer>> GetAllManufacturer();
        public Task<Manufacturer?> GetByIdManufacturer(int id);
        public Task AddManufacturer(Manufacturer manufacturerNew);
        public Task UpdateManufacturer(Manufacturer manufacturerUpdate);
        public Task DeleteManufacturer(int id);
    }
}

using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services.Interfaces
{
    public interface IManufacturerService
    {
        public Task<List<Manufacturer>> GetAllManufacturer();
        public Task<List<ManufacturerViewModel>> GetAllManufacturerViewModel();
        public Task<ManufacturerViewModel?> GetByIdManufacturerViewModel(int id);
        public Task<List<ValidationResult>> AddManufacturer(ManufacturerViewModel manufacturerNew);
        public Task<List<ValidationResult>> UpdateManufacturer(ManufacturerViewModel manufacturerUpdate);
        public Task DeleteManufacturer(int id);
    }
}

using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels.CarViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services.Interfaces

{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllCarViewModel();
        Task<IEnumerable<CarAdminViewModel>> GetAllCarAdminViewModel();
        Task <CarViewModel?> GetCarViewModelById(int id);
        Task<CarAdminViewModel?> GetByIdCarAdminViewModel(int id);
        Task<List<ValidationResult>> AddCar(CarAdminViewModel carAdminViewModel);
        Task<List<ValidationResult>> UpdateCar(CarAdminViewModel carUpdate);
        Task DeleteCar(int id);
        
    }
}

using ExpressVoitures.Models.ViewModels.AllCarViewModel;
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
        Task<List<ValidationResult>> UpdateCar(CarAdminViewModel carAdminViewModel);
        Task DeleteCar(int carId);
        Task AddCarImage(CarImageViewModel carImageViewModel, CarAdminViewModel carAdminViewModel);
        Task DeleteCarImage(CarImageViewModel carImageViewModel, CarAdminViewModel carAdminViewModel);

        //Task SetCarImageAsCover(CarImageViewModel carImageViewModel, CarAdminViewModel carAdminViewModel);
        Task SetCarImageAsCover(int imageId, int carId);

    }
}

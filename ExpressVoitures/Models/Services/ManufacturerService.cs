using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
            {
            _manufacturerRepository = manufacturerRepository;
            }

        private List<ManufacturerViewModel> MapToViewModel(IEnumerable<Manufacturer> manufacturersDb)
        {
            List<ManufacturerViewModel> manufacturerViewModels = new List<ManufacturerViewModel>();
            foreach (Manufacturer manufacturer in manufacturersDb)
            {
                manufacturerViewModels.Add(new ManufacturerViewModel
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name
                });
            }

            return manufacturerViewModels;
        }

        private Manufacturer MapToDatabase(ManufacturerViewModel manufacturerViewModel)
        {
            Manufacturer manufacturerNew = new Manufacturer
            {
                Name = manufacturerViewModel.Name,
            };

            return manufacturerNew;
        }


        public async Task<List<Manufacturer>> GetAllManufacturer() 
        {
            IEnumerable<Manufacturer> manufacturerList = await _manufacturerRepository.GetAllManufacturer();
            return manufacturerList.ToList();
        }

        public async Task<List<ManufacturerViewModel>> GetAllManufacturerViewModel() 
        {
            IEnumerable<Manufacturer> manufacturersViewModel = await GetAllManufacturer();
            return MapToViewModel(manufacturersViewModel);
        }

        public async Task<ManufacturerViewModel?> GetByIdManufacturerViewModel(int id) 
        {
            List<ManufacturerViewModel> manufacturerViewModelList = await GetAllManufacturerViewModel();
            ManufacturerViewModel? manufacturerViewModel = manufacturerViewModelList.FirstOrDefault(m => m.Id == id);

            return manufacturerViewModel;
        }

        public async Task<List<ValidationResult>> AddManufacturer(ManufacturerViewModel manufacturerNew)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(manufacturerNew);

            if (!Validator.TryValidateObject(manufacturerNew, context, errors, true))
                return errors;

            var manufacturerToAdd = MapToDatabase(manufacturerNew);
            await _manufacturerRepository.AddManufacturer(manufacturerToAdd);
            manufacturerNew.Id = manufacturerToAdd.Id;

            return new List<ValidationResult>();

        }

        public async Task<List<ValidationResult>> UpdateManufacturer(ManufacturerViewModel manufacturerUpdate)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(manufacturerUpdate);

            if (!Validator.TryValidateObject(manufacturerUpdate, context, errors, true))
                return errors;

            var manufacturerNew = MapToDatabase(manufacturerUpdate);
            manufacturerNew.Id = manufacturerUpdate.Id;
            await _manufacturerRepository.UpdateManufacturer(manufacturerNew);
            return new List<ValidationResult>();
        }

        public async Task DeleteManufacturer(int id)
        {
            await _manufacturerRepository.DeleteManufacturer(id);
        }

        public async Task<List<ManufacturerDashboardViewModel>> GetAllManufacturerForDashboard()
        {

            IEnumerable<Manufacturer> manufacturerList = await _manufacturerRepository.GetAllManufacturerWithInclude();
            List<ManufacturerDashboardViewModel> manufacturerDashboardList = new List<ManufacturerDashboardViewModel>();


            foreach (var manufacturer in manufacturerList) 
            {
                int countVehicleModels = manufacturer.VehicleModel.Count;
                int countFinition = manufacturer.VehicleModel.Sum(f => f.Finition.Count);

                ManufacturerDashboardViewModel manufacturerDashboardViewModel = new ManufacturerDashboardViewModel
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    CountVehicleModel = countVehicleModels,
                    CountFinition = countFinition
                };

                manufacturerDashboardList.Add(manufacturerDashboardViewModel);

            }

            return manufacturerDashboardList;

        }

    }
}

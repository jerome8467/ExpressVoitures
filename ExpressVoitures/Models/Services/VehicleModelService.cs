using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        private List<VehicleModelViewModel> MapToViewModel(IEnumerable<VehicleModel> vehicleModelDb)
        {
            List<VehicleModelViewModel> vehicleModelViewModels = new List<VehicleModelViewModel>();
            foreach (VehicleModel vehicleModel in vehicleModelDb)
            {
                vehicleModelViewModels.Add(new VehicleModelViewModel
                {
                    Id = vehicleModel.Id,
                    Name = vehicleModel.Name,
                    ManufacturerId = vehicleModel.ManufacturerId,

                });
            }

            return vehicleModelViewModels;
        }

        private VehicleModel MapToDatabase(VehicleModelViewModel vehicleModelViewModel)
        {
            VehicleModel vehicleModel = new VehicleModel
            {
                Name = vehicleModelViewModel.Name,
                ManufacturerId = vehicleModelViewModel.ManufacturerId
            };

            return vehicleModel;
        }

        public async Task<List<VehicleModel>> GetAllVehicleModelByManufacturer(int manufacturerId)
        {
            IEnumerable<VehicleModel> vehicleModelList = await _vehicleModelRepository.GetAllVehicleModelByManufacturer(manufacturerId);
            return vehicleModelList.ToList();
        }
        public async Task<List<VehicleModel>> GetAllVehicleModel()
        {
            IEnumerable<VehicleModel> vehicleModelList = await _vehicleModelRepository.GetAllVehicleModel();
            return vehicleModelList.ToList();
        }

        public async Task<List<VehicleModelViewModel>> GetAllVehicleModelViewModelByManufacturer(int manufacturerId)
        {
            IEnumerable<VehicleModel> vehicleModelViewModel = await _vehicleModelRepository.GetAllVehicleModelByManufacturer(manufacturerId);
            return MapToViewModel(vehicleModelViewModel);
        }

        public async Task<VehicleModelViewModel?> GetByIdVehicleModelViewModel(VehicleModelViewModel vehicleModelView)
        {
            List<VehicleModelViewModel> vehicleModelViewModelList = await GetAllVehicleModelViewModelByManufacturer(vehicleModelView.ManufacturerId);
            VehicleModelViewModel? vehicleModelViewModel = vehicleModelViewModelList.FirstOrDefault(v => v.Id == vehicleModelView.Id);
            return vehicleModelViewModel;
        }

        public async Task<List<ValidationResult>> AddVehicleModel(VehicleModelViewModel vehicleModelNew)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(vehicleModelNew);

            if (!Validator.TryValidateObject(vehicleModelNew, context, errors, true))
                return errors;

            var vehicleModelToAdd = MapToDatabase(vehicleModelNew);
            await _vehicleModelRepository.AddVehicleModel(vehicleModelToAdd);
            vehicleModelNew.Id = vehicleModelToAdd.Id;

            return new List<ValidationResult>();
        }

        public async Task<List<ValidationResult>> UpdateVehicleModel(VehicleModelViewModel vehicleModelUpdate)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(vehicleModelUpdate);

            if (!Validator.TryValidateObject(vehicleModelUpdate, context, errors, true))
                return errors;

            var vehicleModelNew = MapToDatabase(vehicleModelUpdate);
            vehicleModelNew.Id = vehicleModelUpdate.Id;
            await _vehicleModelRepository.UpdateVehicleModel(vehicleModelNew);

            return new List<ValidationResult>();
        }

        public async Task DeleteVehicleModel(int id)
        {
            await _vehicleModelRepository.DeleteVehicleModel(id);
        }


    }
}

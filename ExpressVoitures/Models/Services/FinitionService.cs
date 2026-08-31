using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.Repositories.Interfaces;
using ExpressVoitures.Models.Services.Interfaces;
using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services
{
    public class FinitionService : IFinitionService
    {
        private readonly IFinitionRepository _finitionRepository;

        public FinitionService(IFinitionRepository finitionRepository)
        {
            _finitionRepository = finitionRepository;

        }

        private List<FinitionViewModel> MapToViewModel(IEnumerable<Finition> finitionDb)
        {
            List<FinitionViewModel> finitionViewModel = new List<FinitionViewModel>();
            foreach(Finition finition in finitionDb)
            {
                finitionViewModel.Add(new FinitionViewModel
                {
                    Id = finition.Id,
                    Name = finition.Name,
                    VehicleModelId = finition.VehicleModelId,
                    /*VehicleModelName = finition.VehicleModel?.Name,*/
                });
            }

            return finitionViewModel;
        }

        private Finition MapToDatabase(FinitionViewModel finitionViewModel)
        {
            Finition finitionNew = new Finition
            {
                Name = finitionViewModel.Name,
                VehicleModelId = finitionViewModel.VehicleModelId
            };

            return finitionNew;
        }

        public async Task<List<Finition>> GetAllFinitionByVehicleModel(int vehicleModelId)
        {
            IEnumerable<Finition> finitionList = await _finitionRepository.GetAllFinitionByVehicleModel(vehicleModelId);
            return finitionList.ToList();
        }
        public async Task<List<Finition>> GetAllFinition()
        {
            IEnumerable<Finition> finitionList = await _finitionRepository.GetAllFinition();
            return finitionList.ToList();
        }

        public async Task<List<FinitionViewModel>> GetAllFinitionViewModelByVehicleModel(int vehicleModelId)
        {
            IEnumerable<Finition> finitionViewModel = await _finitionRepository.GetAllFinitionByVehicleModel(vehicleModelId);
            return MapToViewModel(finitionViewModel);
        }

        public async Task<FinitionViewModel?> GetByIdFinitionViewModel(FinitionViewModel finitionView)
        {
            List<FinitionViewModel> finitionViewModelList = await GetAllFinitionViewModelByVehicleModel(finitionView.VehicleModelId);
            FinitionViewModel? finitionViewModel = finitionViewModelList.FirstOrDefault(F => F.Id == finitionView.Id);
            return finitionViewModel;
        }

        public async Task<List<ValidationResult>> AddFinition(FinitionViewModel finitionNew)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(finitionNew);

            if (!Validator.TryValidateObject(finitionNew, context, errors, true))
                return errors;

            var finitionToAdd = MapToDatabase(finitionNew);
            await _finitionRepository.AddFinition(finitionToAdd);
            finitionNew.Id = finitionToAdd.Id;

            return new List<ValidationResult>();
        }
        public async Task<List<ValidationResult>> UpdateFinition(FinitionViewModel finitionUpdate)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(finitionUpdate);

            if (!Validator.TryValidateObject(finitionUpdate, context, errors, true))
                return errors;

            var finitionNew = MapToDatabase(finitionUpdate);
            finitionNew.Id = finitionUpdate.Id;
            await _finitionRepository.UpdateFinition(finitionNew);

            return new List<ValidationResult>();
        }

        public async Task DeleteFinition(int id)
        {
            await _finitionRepository.DeleteFinition(id);
        }

    }
}

using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Services.Interfaces
{
    public interface IFinitionService
    {
        public Task<List<Finition>> GetAllFinition();
        public Task<List<FinitionViewModel>> GetAllFinitionViewModel();
        public Task<FinitionViewModel?> GetByIdFinitionViewModel(int id);
        public Task<List<ValidationResult>> AddFinition(FinitionViewModel finitionNew);
        public Task<List<ValidationResult>> UpdateFinition(FinitionViewModel finitionUpdate);
        public Task DeleteFinition(int id);
    }
}

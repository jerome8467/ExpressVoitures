using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels
{
    public class FinitionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingFinition")]
        public required string Name { get; set; }

        public string? VehicleModelName { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        public int VehicleModelId { get; set; }
    }
}

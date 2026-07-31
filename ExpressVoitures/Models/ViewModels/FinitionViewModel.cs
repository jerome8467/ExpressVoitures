using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
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
        public int VehicleModelId { get; set; }
    }
}

using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels
{
    public class VehicleModelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        public string? Name { get; set; }

        public int ManufacturerId { get; set; }
    }
}

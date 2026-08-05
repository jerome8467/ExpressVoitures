using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels.AllManufacturerViewModel
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingManufacturer")]
        public required string Name { get; set; }
    }
}

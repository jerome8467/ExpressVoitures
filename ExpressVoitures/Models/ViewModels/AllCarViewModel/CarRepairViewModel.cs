using ExpressVoitures.Attributes;
using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels.AllCarViewModel
{
    public class CarRepairViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingRepairPrice")]
        [DoubleValidation]
        public double RepairPrice { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingTypeOfRepair")]
        public required string TypeOfRepair { get; set; }

        public int CarId { get; set; }

    }
}

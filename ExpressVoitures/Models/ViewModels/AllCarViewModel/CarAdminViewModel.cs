using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using ExpressVoitures.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels.AllCarViewModel
{
    public class CarAdminViewModel
    {
        public int CarId { get; set; }
        public double SalePrice { get; set; }


        ///////////////////////// SECTION INFORMATION /////////////////////////
        // Entities : Car

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingManufacturer")]
        public int ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        public int VehicleModelId { get; set; }
        public string? VehicleModelName { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingFinition")]
        public int FinitionId { get; set; }
        public string? FinitionName { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingYear")]
        [IntegerValidation]
        public required string Year { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingKilometer")]
        [IntegerValidation]
        public required string Kilometer { get; set; }

        public string? Description { get; set; }


        ///////////////////////// SECTION STATUT /////////////////////////
        // Entities : Car
        public bool Available { get; set; }


        ///////////////////////// SECTION REPAIR /////////////////////////
        // Entities : CarRepair
        public int CarRepairId { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingRepairPrice")]
        [DoubleValidation]
        public double RepairPrice { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingTypeOfRepair")]
        public required string TypeOfRepair { get; set; }


        ///////////////////////// SECTION TRANSACTION /////////////////////////
        // Entities : CarTransaction
        public int CarTransactionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingDate")]
        public DateOnly PurchaseDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingPurchasePrice")]
        [DoubleValidation]
        public double PurchasePrice { get; set; }

        public DateOnly? AvailabilityDate { get; set; }
        public DateOnly? SaleDate { get; set; }


        ///////////////////////// SECTION IMAGE /////////////////////////
        // Entities : CarImage
        public List<CarImageViewModel> ImagesList { get; set; } = new List<CarImageViewModel>();
    }
}

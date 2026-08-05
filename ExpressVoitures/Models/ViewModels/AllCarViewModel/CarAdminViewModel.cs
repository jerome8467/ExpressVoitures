using ExpressVoitures.Attributes;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
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
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingManufacturer")]
        public int? ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        public int? VehicleModelId { get; set; }
        public string? VehicleModelName { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingFinition")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingFinition")]
        public int? FinitionId { get; set; } 
        public string? FinitionName { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingYear")]
        [IntegerValidation]
        public string Year { get; set; } = DateTime.Now.Year.ToString();


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingKilometer")]
        [IntegerValidation]
        public string? Kilometer { get; set; }

        public string? Description { get; set; }


        ///////////////////////// SECTION STATUT /////////////////////////
        // Entities : Car
        public CarStatus Status { get; set; }


        ///////////////////////// SECTION REPAIR /////////////////////////
        // Entities : CarRepair
        public int CarRepairId { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingRepairPrice")]
        [DoubleValidation]
        public string? RepairPrice { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingTypeOfRepair")]
        public string? TypeOfRepair { get; set; }


        ///////////////////////// SECTION TRANSACTION /////////////////////////
        // Entities : CarTransaction
        public int CarTransactionId { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingDate")]
        public DateOnly? PurchaseDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingPurchasePrice")]
        [DoubleValidation]
        public string? PurchasePrice { get; set; }

        public double AdditionalAmount { get; set; } = 0;

        public DateOnly? AvailabilityDate { get; set; }
        public DateOnly? SaleDate { get; set; }



        ///////////////////////// SECTION IMAGE /////////////////////////
        // Entities : CarImage
        public List<CarImageViewModel>? ImagesList { get; set; }
    }
}

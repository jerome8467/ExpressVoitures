using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using ExpressVoitures.Attributes;
using ExpressVoitures.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels
{
    public class CarAdminViewModel
    {
        public int CarId { get; set; }


        //SECTION INFORMATION
        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingManufacturer")]
        public int ManufacturerId { get; set; }
        public List<Manufacturer>? Manufacturers { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingVehicleModel")]
        public int VehicleModelId { get; set; }
        public List<VehicleModel>? VehicleModels { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingFinition")]
        public int FinitionId { get; set; }
        public List<Finition>? Finitions { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingYear")]
        [IntegerValidation]
        public required string Year { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingKilometer")]
        [IntegerValidation]
        public required string Kilometer { get; set; }

        public string? Description { get; set; }


        //SECTION STATUT
        public bool Available { get; set; }


        //SECTION REPAIR
        public int CarRepairId { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingRepairPrice")]
        [DoubleValidation]
        public double RepairPrice { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingTypeOfRepair")]
        public required string TypeOfRepair { get; set; }


        //SECTION TRANSACTION
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


        //SECTION IMAGE
        public int CarImageId { get; set; }
        public List<CarImage>? CarImages { get; set; }
    }
}

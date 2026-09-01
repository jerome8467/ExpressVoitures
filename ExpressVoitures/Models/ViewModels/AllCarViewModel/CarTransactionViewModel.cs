using ExpressVoitures.Attributes;
using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels.AllCarViewModel
{
    public class CarTransactionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingDate")]
        public DateOnly PurchaseDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(CarAdminViewModelResources),
            ErrorMessageResourceName = "MissingPurchasePrice")]
        [DoubleValidation]
        public double PurchasePrice { get; set; }
        public DateOnly? AvailabilityDate { get; set; }
        public DateOnly? SaleDate { get; set; }

        public double AdditionalAmount { get; set; }

        public required int CarId { get; set; }
    }
}

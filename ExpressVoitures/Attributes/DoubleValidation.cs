using System.ComponentModel.DataAnnotations;
using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;

namespace ExpressVoitures.Attributes
{
    public class DoubleValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (!double.TryParse(value?.ToString(), out double Double))
                return new ValidationResult(CarAdminViewModelResources.NotNumber, new[] { validationContext.MemberName ?? string.Empty });

            if (Convert.ToDouble(Double) <= 0)
                return new ValidationResult(CarAdminViewModelResources.NumberNotGreaterZero, new[] { validationContext.MemberName ?? string.Empty });


            return ValidationResult.Success;
        }

    }
}
using System.ComponentModel.DataAnnotations;
using ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel;

namespace ExpressVoitures.Attributes
{
    public class IntegerValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (!int.TryParse(value?.ToString(), out int Integer))
                return new ValidationResult(CarAdminViewModelResources.NumberNotInteger, new[] { "Integer" });

            if (Convert.ToDouble(Integer) <= 0)
                return new ValidationResult(CarAdminViewModelResources.NumberNotGreaterZero, new[] { "Integer" });


            return ValidationResult.Success;
        }

    }
}

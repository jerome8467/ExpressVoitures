using ExpressVoitures.Models.ViewModels.AllManufacturerViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;


namespace ExpressVoituresTest.Unitaire.Annotation
{
    public class ManufacturerTest
    {

        private const string ValidName = "Toyota";
        private string? validateName;

        private void ValidateManufacturerViewModel(ManufacturerViewModel model)
        {
            validateName = "";
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, errors, true);
            if (errors.Any(e => e.MemberNames.Contains("Name"))) { validateName = "NameWrong"; }
            else { validateName = "NameValid"; }
        }

        [Fact]
        public void Manufacturer_With_NameEmpty()
        {
            // Arrange
            ManufacturerViewModel model = new ManufacturerViewModel { Name = "" };

            // Act
            ValidateManufacturerViewModel(model);

            // Assert
            Assert.Equal("NameWrong", validateName);
        }

        [Fact]
        public void Manufacturer_With_Name()
        {
            // Arrange
            ManufacturerViewModel model = new ManufacturerViewModel { Name = ValidName };

            // Act
            ValidateManufacturerViewModel(model);

            // Assert
            Assert.Equal("NameValid", validateName);
        }



    }
}

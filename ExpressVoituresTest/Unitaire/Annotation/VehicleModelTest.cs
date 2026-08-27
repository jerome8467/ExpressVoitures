using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;



namespace ExpressVoituresTest.Unitaire.Annotation
{
    public class VehicleModelTest
    {

        private const string ValidName = "CHR";
        private const int ValidId = 3;

        private string? validateName;
        private string? validateId;

        private void ValidateVehicleModelViewModel(VehicleModelViewModel model)
        {
            validateName = "";
            validateId = "";
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, errors, true);
            if (errors.Any(e => e.MemberNames.Contains("Name"))) { validateName = "NameWrong"; }
            else { validateName = "NameValid"; }
            if (errors.Any(e => e.MemberNames.Contains("ManufacturerId"))) { validateId = "IdWrong"; }
            else { validateId = "IdValid"; }
        }

        [Fact]
        public void VehicleMode_with_allEmpty()
        {
            // Arrange
            VehicleModelViewModel model = new VehicleModelViewModel { Name = "", ManufacturerId = 0 };

            //Act
            ValidateVehicleModelViewModel(model);

            // Assert
            Assert.Equal("NameWrong", validateName);
            Assert.Equal("IdWrong", validateId);
        }

        [Fact]
        public void VehicleMode_with_NameEmpty()
        {
            // Arrange
            VehicleModelViewModel model = new VehicleModelViewModel { Name = "", ManufacturerId = ValidId };

            //Act
            ValidateVehicleModelViewModel(model);

            // Assert
            Assert.Equal("NameWrong", validateName);
            Assert.Equal("IdValid", validateId);
        }

        [Fact]
        public void VehicleMode_with_IdZero()
        {
            // Arrange
            VehicleModelViewModel model = new VehicleModelViewModel { Name = ValidName, ManufacturerId = 0 };

            //Act
            ValidateVehicleModelViewModel(model);

            // Assert
            Assert.Equal("NameValid", validateName);
            Assert.Equal("IdWrong", validateId);
        }

        [Fact]
        public void VehicleMode_with_AllValid()
        {
            // Arrange
            VehicleModelViewModel model = new VehicleModelViewModel { Name = ValidName, ManufacturerId = ValidId };

            //Act
            ValidateVehicleModelViewModel(model);

            // Assert
            Assert.Equal("NameValid", validateName);
            Assert.Equal("IdValid", validateId);
        }

    }
}

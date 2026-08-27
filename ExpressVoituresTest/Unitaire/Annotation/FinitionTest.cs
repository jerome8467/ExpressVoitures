using ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresTest.Unitaire.Annotation
{
    public class FinitionTest
    {

        private const string ValidName = "Graphique 1.8";
        private const int ValidId = 3;

        private string? validateName;
        private string? validateId;

        private void ValidateFinitionViewModel(FinitionViewModel model)
        {
            validateName = "";
            validateId = "";
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, errors, true);
            if(errors.Any(e => e.MemberNames.Contains("Name"))) { validateName = "NameWrong"; }
            else { validateName = "NameValid"; }
            if(errors.Any(e => e.MemberNames.Contains("VehicleModelId"))) { validateId = "IdWrong"; }
            else { validateId = "IdValid"; }
        }

        [Fact]
        public void Finition_with_allEmpty()
        {
            // Arrange
            FinitionViewModel model = new FinitionViewModel { Name = "", VehicleModelId = 0 };

            //Act
            ValidateFinitionViewModel(model);

            // Assert
            Assert.Equal("NameWrong", validateName);
            Assert.Equal("IdWrong", validateId);
        }

        [Fact]
        public void Finition_with_NameEmpty()
        {
            // Arrange
            FinitionViewModel model = new FinitionViewModel { Name = "", VehicleModelId = ValidId };

            //Act
            ValidateFinitionViewModel(model);

            // Assert
            Assert.Equal("NameWrong", validateName);
            Assert.Equal("IdValid", validateId);
        }

        [Fact]
        public void Finition_with_IdZero()
        {
            // Arrange
            FinitionViewModel model = new FinitionViewModel { Name = ValidName, VehicleModelId = 0 };

            //Act
            ValidateFinitionViewModel(model);

            // Assert
            Assert.Equal("NameValid", validateName);
            Assert.Equal("IdWrong", validateId);
        }

        [Fact]
        public void Finition_with_AllValid()
        {
            // Arrange
            FinitionViewModel model = new FinitionViewModel { Name = ValidName, VehicleModelId = ValidId };

            //Act
            ValidateFinitionViewModel(model);

            // Assert
            Assert.Equal("NameValid", validateName);
            Assert.Equal("IdValid", validateId);
        }

    }
}

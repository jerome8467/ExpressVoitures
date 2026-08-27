using ExpressVoitures.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace ExpressVoituresTest.Unitaire.Annotation
{
    public class LoginTest
    {

        private const string ValidEmail = "admin@expressvoitures.fr";
        private const string ValidPassword = "Password123!";

        private string? validateEmail;
        private string? validatePassword;

        private void ValidateLoginViewModel(LoginViewModel model)
        {
            validateEmail = "";
            validatePassword = "";
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, errors, true);
            if (errors.Any(e => e.MemberNames.Contains("Email"))) { validateEmail = "EmailWrong"; }
            else { validateEmail = "EmailValid"; }
            if (errors.Any(e => e.MemberNames.Contains("Password"))) { validatePassword = "PasswordWrong"; }
            else { validatePassword = "PasswordValid"; }
        }

        [Fact]
        public void Login_With_AllWrong()
        {
            // Arrange
            LoginViewModel model = new LoginViewModel { Email = "", Password = "" };

            // Act
            ValidateLoginViewModel(model);

            // Assert
            Assert.Equal("EmailWrong", validateEmail);
            Assert.Equal("PasswordWrong", validatePassword);
        }

        [Fact]
        public void Login_With_PasswordWrong()
        {
            // Arrange
            LoginViewModel model = new LoginViewModel { Email = ValidEmail, Password = "" };

            // Act
            ValidateLoginViewModel(model);

            // Assert
            Assert.Equal("EmailValid", validateEmail);
            Assert.Equal("PasswordWrong", validatePassword);
        }

        [Fact]
        public void Login_With_EmailWrong()
        {
            // Arrange
            LoginViewModel model = new LoginViewModel { Email = "", Password = ValidPassword };

            // Act
            ValidateLoginViewModel(model);

            // Assert
            Assert.Equal("EmailWrong", validateEmail);
            Assert.Equal("PasswordValid", validatePassword);
        }

        [Fact]
        public void Login_With_EmailFormatInvalid()
        {
            // Arrange
            LoginViewModel model = new LoginViewModel { Email = "pasunemail", Password = ValidPassword };

            // Act
            ValidateLoginViewModel(model);

            // Assert
            Assert.Equal("EmailWrong", validateEmail);
            Assert.Equal("PasswordValid", validatePassword);
        }

        [Fact]
        public void Login_With_AllValid()
        {
            // Arrange
            LoginViewModel model = new LoginViewModel { Email = ValidEmail, Password = ValidPassword };

            // Act
            ValidateLoginViewModel(model);

            // Assert
            Assert.Equal("EmailValid", validateEmail);
            Assert.Equal("PasswordValid", validatePassword);
        }
    }
}
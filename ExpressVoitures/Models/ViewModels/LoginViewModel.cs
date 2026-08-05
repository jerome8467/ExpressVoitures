using ExpressVoitures.Resources.Models.ViewModels.LoginViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessageResourceType = typeof(LoginViewModelResources),
            ErrorMessageResourceName = "MissingEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(LoginViewModelResources),
            ErrorMessageResourceName = "InvalidEmail")]
        public required string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(LoginViewModelResources),
            ErrorMessageResourceName = "MissingPassword")]
        public required string Password { get; set; }

        public string? ReturnUrl { get; set; } = "/";

    }
}

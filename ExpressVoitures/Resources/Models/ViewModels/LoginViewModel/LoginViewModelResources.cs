using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Models.ViewModels.LoginViewModel
{
    public static class LoginViewModelResources
    {
        private static ResourceManager ResourceManager = new ResourceManager(typeof(LoginViewModelResources));
        private static CultureInfo? CultureInfo;

        public static string MissingEmail 
        {
            get
            {
                return ResourceManager.GetString("MissingEmail", CultureInfo) ?? string.Empty;
            }
        }

        public static string InvalidEmail
        {
            get
            {
                return ResourceManager.GetString("InvalidEmail", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingPassword
        {
            get
            {
                return ResourceManager.GetString("MissingPassword", CultureInfo) ?? string.Empty;
            }
        }


    }
}

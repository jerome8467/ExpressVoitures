using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Views.Account
{
    public static class LoginViewResources
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(LoginViewResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");


        public static string Title
        {
            get
            {
                return ResourceManager.GetString("Title", CultureInfo) ?? string.Empty;
            }
        }

        public static string Email
        {
            get
            {
                return ResourceManager.GetString("Email", CultureInfo) ?? string.Empty;
            }
        }

        public static string Password
        {
            get
            {
                return ResourceManager.GetString("Password", CultureInfo) ?? string.Empty;
            }
        }

        public static string Submit
        {
            get
            {
                return ResourceManager.GetString("Submit", CultureInfo) ?? string.Empty;
            }
        }


    }
}

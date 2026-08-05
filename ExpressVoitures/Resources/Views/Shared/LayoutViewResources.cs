using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Views.Shared
{
    public static class LayoutViewResources
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(LayoutViewResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");


        public static string Home
        {
            get
            {
                return ResourceManager.GetString("Home", CultureInfo) ?? string.Empty;
            }
        }

        public static string OurCars
        {
            get
            {
                return ResourceManager.GetString("OurCars", CultureInfo) ?? string.Empty;
            }
        }

        public static string AddCar
        {
            get
            {
                return ResourceManager.GetString("AddCar", CultureInfo) ?? string.Empty;
            }
        }

        public static string GoToAdmin
        {
            get
            {
                return ResourceManager.GetString("GoToAdmin", CultureInfo) ?? string.Empty;
            }
        }

        public static string Logout
        {
            get
            {
                return ResourceManager.GetString("Logout", CultureInfo) ?? string.Empty;
            }
        }

        public static string Login
        {
            get
            {
                return ResourceManager.GetString("Login", CultureInfo) ?? string.Empty;
            }
        }

    }
}

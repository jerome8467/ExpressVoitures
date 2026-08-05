using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Views.Home
{
    public static class HomeViewResources
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(HomeViewResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");

        public static string Slogan
        {
            get
            {
                return ResourceManager.GetString("Slogan", CultureInfo) ?? string.Empty;
            }
        }

        public static string Description
        {
            get
            {
                return ResourceManager.GetString("Description", CultureInfo) ?? string.Empty;
            }
        }

        public static string SeeOurCars
        {
            get
            {
                return ResourceManager.GetString("SeeOurCars", CultureInfo) ?? string.Empty;
            }
        }

    }
}

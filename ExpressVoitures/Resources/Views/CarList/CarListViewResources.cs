using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Views.CarList
{
    public static class CarListViewResources
    {
        private static readonly ResourceManager resourceManager = new ResourceManager(typeof(CarListViewResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");


        public static string Title
        {
            get
            {
                return resourceManager.GetString("Title", CultureInfo) ?? string.Empty;
            }
        }

        public static string Finition
        {
            get
            {
                return resourceManager.GetString("Finition", CultureInfo) ?? string.Empty;
            }
        }

        public static string Price
        {
            get
            {
                return resourceManager.GetString("Price", CultureInfo) ?? string.Empty;
            }
        }
        public static string Year
        {
            get
            {
                return resourceManager.GetString("Year", CultureInfo) ?? string.Empty;
            }
        }
        public static string Kilometer
        {
            get
            {
                return resourceManager.GetString("Kilometer", CultureInfo) ?? string.Empty;
            }
        }
        public static string Delete
        {
            get
            {
                return resourceManager.GetString("Delete", CultureInfo) ?? string.Empty;
            }
        }
        public static string Change
        {
            get
            {
                return resourceManager.GetString("Change", CultureInfo) ?? string.Empty;
            }
        }
        public static string AdminMode
        {
            get
            {
                return resourceManager.GetString("AdminMode", CultureInfo) ?? string.Empty;
            }
        }
        public static string AdminTxt
        {
            get
            {
                return resourceManager.GetString("AdminTxt", CultureInfo) ?? string.Empty;
            }
        }
        public static string Description
        {
            get
            {
                return resourceManager.GetString("Description", CultureInfo) ?? string.Empty;
            }
        }
    }
}

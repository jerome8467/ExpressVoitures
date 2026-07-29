using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Models.ViewModels.CarAdminViewModel
{
    public class CarAdminViewModelResources
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(CarAdminViewModelResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");

        public static string NotNumber
        {
            get
            {
                return ResourceManager.GetString("NotNumber", CultureInfo) ?? string.Empty;
            }
        }

        public static string NumberNotGreaterZero
        {
            get
            {
                return ResourceManager.GetString("NumberNotGreaterZero", CultureInfo) ?? string.Empty;
            }
        }

        public static string NumberNotInteger
        {
            get
            {
                return ResourceManager.GetString("NumberNotInteger", CultureInfo) ?? string.Empty;
            }
        }


        public static string MissingManufacturer
        {
            get
            {
                return ResourceManager.GetString("MissingManufacturer", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingVehicleModel
        {
            get
            {
                return ResourceManager.GetString("MissingVehicleModel", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingFinition
        {
            get
            {
                return ResourceManager.GetString("MissingFinition", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingYear
        {
            get
            {
                return ResourceManager.GetString("MissingYear", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingKilometer
        {
            get
            {
                return ResourceManager.GetString("MissingKilometer", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingRepairPrice
        {
            get
            {
                return ResourceManager.GetString("MissingRepairPrice", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingTypeOfRepair
        {
            get
            {
                return ResourceManager.GetString("MissingTypeOfRepair", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingPurchasePrice
        {
            get
            {
                return ResourceManager.GetString("MissingPurchasePrice", CultureInfo) ?? string.Empty;
            }
        }

        public static string MissingDate
        {
            get
            {
                return ResourceManager.GetString("MissingDate", CultureInfo) ?? string.Empty;
            }
        }


    }
}

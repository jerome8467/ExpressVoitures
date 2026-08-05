using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Views.Manufacturer
{
    public static class ManufacturerIndexResources
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(ManufacturerIndexResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");

        public static string Manufacturer
        {
            get
            {
                return ResourceManager.GetString("Manufacturer", CultureInfo) ?? string.Empty;
            }
        }

        public static string NameManufacturer
        {
            get
            {
                return ResourceManager.GetString("NameManufacturer", CultureInfo) ?? string.Empty;
            }
        }

        public static string Add
        {
            get
            {
                return ResourceManager.GetString("Add", CultureInfo) ?? string.Empty;
            }
        }

        public static string VehicleModel
        {
            get
            {
                return ResourceManager.GetString("VehicleModel", CultureInfo) ?? string.Empty;
            }
        }
        public static string NameVehicleModel
        {
            get
            {
                return ResourceManager.GetString("NameVehicleModel", CultureInfo) ?? string.Empty;
            }
        }
        public static string Finition
        {
            get
            {
                return ResourceManager.GetString("Finition", CultureInfo) ?? string.Empty;
            }
        }
        public static string NameFinition
        {
            get
            {
                return ResourceManager.GetString("NameFinition", CultureInfo) ?? string.Empty;
            }
        }
        public static string Edit
        {
            get
            {
                return ResourceManager.GetString("Edit", CultureInfo) ?? string.Empty;
            }
        }
        public static string Delete
        {
            get
            {
                return ResourceManager.GetString("Delete", CultureInfo) ?? string.Empty;
            }
        }




    }
}
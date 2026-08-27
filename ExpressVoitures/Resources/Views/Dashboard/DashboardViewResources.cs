using ExpressVoitures.Resources.Views.CarList;
using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Views.Dashboard
{
    public static class DashboardViewResources
    {
        private static readonly ResourceManager resourceManager = new ResourceManager(typeof(DashboardViewResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");


        public static string AverageRepairCost
        {
            get
            {
                return resourceManager.GetString("AverageRepairCost", CultureInfo) ?? string.Empty;
            }
        }
        public static string CarsInRepair
        {
            get
            {
                return resourceManager.GetString("CarsInRepair", CultureInfo) ?? string.Empty;
            }
        }
        public static string CarsForSale
        {
            get
            {
                return resourceManager.GetString("CarsForSale", CultureInfo) ?? string.Empty;
            }
        }
        public static string CarsSold
        {
            get
            {
                return resourceManager.GetString("CarsSold", CultureInfo) ?? string.Empty;
            }
        }
        public static string TotalRevenue
        {
            get
            {
                return resourceManager.GetString("TotalRevenue", CultureInfo) ?? string.Empty;
            }
        }
        public static string AverageDaysBeforeSale
        {
            get
            {
                return resourceManager.GetString("AverageDaysBeforeSale", CultureInfo) ?? string.Empty;
            }
        }
        
        public static string AddNewManufacturer
        {
            get
            {
                return resourceManager.GetString("AddNewManufacturer", CultureInfo) ?? string.Empty;
            }
        }
        public static string ListManufacturer
        {
            get
            {
                return resourceManager.GetString("ListManufacturer", CultureInfo) ?? string.Empty;
            }
        }
        public static string ListCar
        {
            get
            {
                return resourceManager.GetString("ListCar", CultureInfo) ?? string.Empty;
            }
        }
        public static string Days
        {
            get
            {
                return resourceManager.GetString("Days", CultureInfo) ?? string.Empty;
            }
        }

        public static string Manufacturer
        {
            get
            {
                return resourceManager.GetString("Manufacturer", CultureInfo) ?? string.Empty;
            }
        }
        public static string VehicleModel
        {
            get
            {
                return resourceManager.GetString("VehicleModel", CultureInfo) ?? string.Empty;
            }
        }
        public static string Finition
        {
            get
            {
                return resourceManager.GetString("Finition", CultureInfo) ?? string.Empty;
            }
        }

        public static string PurchasePrice
        {
            get
            {
                return resourceManager.GetString("PurchasePrice", CultureInfo) ?? string.Empty;
            }
        }
        public static string RepairPrice
        {
            get
            {
                return resourceManager.GetString("RepairPrice", CultureInfo) ?? string.Empty;
            }
        }

        public static string Status
        {
            get
            {
                return resourceManager.GetString("Status", CultureInfo) ?? string.Empty;
            }
        }
        public static string CountVehicleModel
        {
            get
            {
                return resourceManager.GetString("CountVehicleModel", CultureInfo) ?? string.Empty;
            }
        }
        public static string CountFinition
        {
            get
            {
                return resourceManager.GetString("CountFinition", CultureInfo) ?? string.Empty;
            }
        }
    }
}

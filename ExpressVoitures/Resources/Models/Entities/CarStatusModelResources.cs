using ExpressVoitures.Models.Entities;
using System.Globalization;
using System.Resources;

namespace ExpressVoitures.Resources.Models.Entities
{
    public static class CarStatusModelResources
    {

        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(CarStatusModelResources));
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-FR");

        public static string GetLabel(CarStatus status)
        {
            switch (status)
            {
                case CarStatus.ForSale:
                    return ResourceManager.GetString("ForSale", CultureInfo) ?? string.Empty;
                case CarStatus.Sold:
                    return ResourceManager.GetString("Sold", CultureInfo) ?? string.Empty;
                case CarStatus.InRepair:
                    return ResourceManager.GetString("InRepair", CultureInfo) ?? string.Empty;
                default:
                    return status.ToString();
            }
        }

    }
}

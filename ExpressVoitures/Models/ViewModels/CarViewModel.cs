namespace ExpressVoitures.Models.ViewModels
{
    public class CarViewModel
    {
        public double SalePrice { get; set; }
        public int Year { get; set; }
        public required string Manufacturer { get; set; }
        public required string VehicleModel { get; set; }
        public required string Finition { get; set; }
        public required string Description { get; set; }
        public string? ImageCover { get; set; }
        public List<string>? ImageList { get; set; }

    }
}

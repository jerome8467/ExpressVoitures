namespace ExpressVoitures.Models.ViewModels.CarViewModel
{
    public class CarViewModel
    {
        public double? SalePrice { get; set; }
        public int Year { get; set; }
        public required string Manufacturer { get; set; }
        public required string VehicleModel { get; set; }
        public required string Finition { get; set; }
        public string? Description { get; set; }
        public string? ImageCover { get; set; }
        public List<CarImageViewModel>? ImageList { get; set; }

    }
}

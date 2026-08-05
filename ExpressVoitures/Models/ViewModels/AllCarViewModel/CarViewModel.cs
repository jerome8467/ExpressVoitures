namespace ExpressVoitures.Models.ViewModels.AllCarViewModel
{
    public class CarViewModel
    {
        public int Id { get; set; }
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

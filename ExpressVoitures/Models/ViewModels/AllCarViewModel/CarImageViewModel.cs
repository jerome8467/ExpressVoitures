namespace ExpressVoitures.Models.ViewModels.AllCarViewModel
{
    public class CarImageViewModel
    {
        public int ImageId {  get; set; }
        public int CarId { get; set; }
        public string? ImagePath { get; set; }
        public bool IsCover { get; set; }

    }
}

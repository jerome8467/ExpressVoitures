namespace ExpressVoitures.Models.ViewModels.AllCarViewModel
{
    public class CarImageViewModel
    {
        public int ImageId {  get; set; }
        public required int CarId { get; set; }
        public required string ImagePath { get; set; }
        public bool IsCover { get; set; }

    }
}

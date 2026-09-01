namespace ExpressVoitures.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public required string ImagePath { get; set; }
        public bool IsCover { get; set; }

        public required int CarId { get; set; }

    }
}

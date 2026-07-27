namespace ExpressVoitures.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public bool IsCover { get; set; }

        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
    }
}

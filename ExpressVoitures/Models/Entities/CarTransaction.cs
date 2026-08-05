namespace ExpressVoitures.Models.Entities
{
    public class CarTransaction
    {
        public int Id { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
        public DateOnly? AvailabilityDate { get; set; }
        public DateOnly? SaleDate { get; set; }

        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
    }
}

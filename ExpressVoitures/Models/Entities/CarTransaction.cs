namespace ExpressVoitures.Models.Entities
{
    public class CarTransaction
    {
        public int Id { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
        public DateOnly? AvailabilityDate { get; set; }
        public DateOnly? SaleDate { get; set; }
        public double AdditionalAmount { get; set; } = 500;
        public required int CarId { get; set; }

    }
}

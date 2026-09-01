namespace ExpressVoitures.Models.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required int ManufacturerId { get; set; }

        public ICollection<Finition> Finition { get; set; } = new List<Finition>();
    }
}

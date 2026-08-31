namespace ExpressVoitures.Models.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<VehicleModel> VehicleModel { get; set; } = new List<VehicleModel>();

    }
}

namespace ExpressVoitures.Models.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int ManufacturerId { get; set; }
        /*public Manufacturer? Manufacturer { get; set; }*/

        public ICollection<Finition> Finition { get; set; } = new List<Finition>();
    }
}

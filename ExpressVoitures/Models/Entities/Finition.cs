namespace ExpressVoitures.Models.Entities
{
    public class Finition
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required int VehicleModelId { get; set; }

    }
}

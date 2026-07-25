namespace ExpressVoitures.Models.Entities
{
    public class Finition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VehicleModelId { get; set; }
        public virtual VehicleModel Model { get; set; }
    }
}

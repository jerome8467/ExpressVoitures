namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public double Kilometer { get; set; }
        public string? ImagePath { get; set; }
        public bool Available { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public int VehicleModelId { get; set; }
        public virtual VehicleModel Model { get; set; }

        public int FinitionId { get; set; }
        public virtual Finition Finition { get; set; }

    }
}

namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Kilometer { get; set; }
        public string? Description { get; set; }
        public CarStatus Status { get; set; } = CarStatus.InRepair;

        public int ManufacturerId { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }

        public int VehicleModelId { get; set; }
        public virtual VehicleModel? VehicleModel { get; set; }

        public int FinitionId { get; set; }
        public virtual Finition? Finition { get; set; }

        public CarRepair CarRepair { get; set; } = null!;
        public CarTransaction CarTransaction { get; set; } = null!;
        public ICollection<CarImage>? CarImage { get; set; }

    }
}

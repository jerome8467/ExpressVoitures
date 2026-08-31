namespace ExpressVoitures.Models.Entities
{
    public class CarRepair
    {
        public int Id { get; set; }
        public double RepairPrice { get; set; }
        public required string TypeOfRepair { get; set; }
        public int CarId { get; set; }
        /*public  Car? Car { get; set; }*/

    }
}

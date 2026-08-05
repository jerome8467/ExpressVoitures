namespace ExpressVoitures.Models.ViewModels.AllManufacturerViewModel
{
    public class ManufacturerEditViewModel
    {
        public IEnumerable<ManufacturerViewModel>? Manufacturers { get; set; }
        public IEnumerable<VehicleModelViewModel>? VehicleModels { get; set; }
        public IEnumerable<FinitionViewModel>? Finitions { get; set; }
        public int? SelectedManufacturerId { get; set; }
        public int? SelectedVehicleModelId { get; set; }
        public bool FromAddCar { get; set; }
    }
}

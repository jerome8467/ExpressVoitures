using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels.AllCarViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresTest.Unitaire.Annotation
{
    public class CarAdminTest
    {

        private const int ValidManufacturerId = 1;
        private const int ValidVehicleModelId = 1;
        private const int ValidFinitionId = 1;
        private const string ValidYear = "1991";
        private const string ValidKilometer = "299";
        private const string ValidRepairPrice = "3000";
        private const string ValidTypeOfRepair = "Changement des pneus";
        private readonly DateOnly ValidPurchaseDate = new DateOnly(2025, 8, 27);
        private string ValidPurchasePrice = "1000";

        private string? ValidateManufacturerId;
        private string? ValidateVehicleModelId ;
        private string? ValidateFinitionId;
        private string? ValidateYear;
        private string? ValidateKilometer;
        private string? ValidateRepairPrice;
        private string? ValidateTypeOfRepair;
        private string? ValidatePurchaseDate;
        private string? ValidatePurchasePrice;


        private void ValidateCarAdminViewModel(CarAdminViewModel model)
        {
            ValidateManufacturerId = "";
            ValidateVehicleModelId = "";
            ValidateFinitionId = "";
            ValidateYear = "";
            ValidateKilometer = "";
            ValidateRepairPrice = "";
            ValidateTypeOfRepair = "";
            ValidatePurchaseDate = "";
            ValidatePurchasePrice = "";

            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, errors, true);

            if (errors.Any(e => e.MemberNames.Contains("ManufacturerId"))) { ValidateManufacturerId = "ManufacturerIdWrong"; }
            else { ValidateManufacturerId = "ManufacturerIdValid"; }
            if (errors.Any(e => e.MemberNames.Contains("VehicleModelId"))) { ValidateVehicleModelId = "VehicleModelIdWrong"; }
            else { ValidateVehicleModelId = "VehicleModelIdValid"; }
            if (errors.Any(e => e.MemberNames.Contains("FinitionId"))) { ValidateFinitionId = "FinitionIdWrong"; }
            else { ValidateFinitionId = "FinitionIdValid"; }
            if (errors.Any(e => e.MemberNames.Contains("Year"))) { ValidateYear = "YearWrong"; }
            else { ValidateYear = "YearValid"; }
            if (errors.Any(e => e.MemberNames.Contains("Kilometer"))) { ValidateKilometer = "KilometerWrong"; }
            else { ValidateKilometer = "KilometerValid"; }
            if (errors.Any(e => e.MemberNames.Contains("RepairPrice"))) { ValidateRepairPrice = "RepairPriceWrong"; }
            else { ValidateRepairPrice = "RepairPriceValid"; }
            if (errors.Any(e => e.MemberNames.Contains("TypeOfRepair"))) { ValidateTypeOfRepair = "TypeOfRepairWrong"; }
            else { ValidateTypeOfRepair = "TypeOfRepairValid"; }
            if (errors.Any(e => e.MemberNames.Contains("PurchaseDate"))) { ValidatePurchaseDate = "PurchaseDateWrong"; }
            else { ValidatePurchaseDate = "PurchaseDateValid"; }
            if (errors.Any(e => e.MemberNames.Contains("PurchasePrice"))) { ValidatePurchasePrice = "PurchasePriceWrong"; }
            else { ValidatePurchasePrice = "PurchasePriceValid"; }
        }

        [Fact]
        public void CarAdmin_with_AllEmpty()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = 0,
                VehicleModelId = 0,
                FinitionId = 0,
                Year = "",
                Kilometer = "",
                RepairPrice = "",
                TypeOfRepair = "",
                PurchaseDate = null,
                PurchasePrice = "",
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdWrong", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdWrong", ValidateVehicleModelId);
            Assert.Equal("FinitionIdWrong", ValidateFinitionId);
            Assert.Equal("YearWrong", ValidateYear);
            Assert.Equal("KilometerWrong", ValidateKilometer);
            Assert.Equal("RepairPriceWrong", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairWrong", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateWrong", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceWrong", ValidatePurchasePrice);
        }

        [Fact]
        public void CarAdmin_with_AllValid()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = ValidKilometer,
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        /// <summary>
        /// Tests form validation for Year
        /// </summary

        [Fact]
        public void CarAdmin_with_YearZero()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = "0",
                Kilometer = ValidKilometer,
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearWrong", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        [Fact]
        public void CarAdmin_with_YearNotInteger()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = "ABC",
                Kilometer = ValidKilometer,
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearWrong", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        [Fact]
        public void CarAdmin_with_YearBellowTheMinimum()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = "1989",
                Kilometer = ValidKilometer,
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearWrong", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        /// <summary>
        /// Tests form validation for Kilometer
        /// </summary

        [Fact]
        public void CarAdmin_with_KilometerZero()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = "0",
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerWrong", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        [Fact]
        public void CarAdmin_with_KilometerNotInteger()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = "ABC",
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerWrong", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        /// <summary>
        /// Tests form validation for RepairPrice
        /// </summary

        [Fact]
        public void CarAdmin_with_RepairPriceZero()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = ValidKilometer,
                RepairPrice = "0",
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceWrong", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        [Fact]
        public void CarAdmin_with_RepairPriceNotDouble()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = ValidKilometer,
                RepairPrice = "ABC",
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = ValidPurchasePrice,
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceWrong", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceValid", ValidatePurchasePrice);
        }

        /// <summary>
        /// Tests form validation for PurchasePrice
        /// </summary

        [Fact]
        public void CarAdmin_with_PurchasePriceZero()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = ValidKilometer,
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = "0",
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceWrong", ValidatePurchasePrice);
        }

        [Fact]
        public void CarAdmin_with_PurchasePriceNotDouble()
        {
            // Arrange
            CarAdminViewModel model = new CarAdminViewModel
            {
                ManufacturerId = ValidManufacturerId,
                VehicleModelId = ValidVehicleModelId,
                FinitionId = ValidFinitionId,
                Year = ValidYear,
                Kilometer = ValidKilometer,
                RepairPrice = ValidRepairPrice,
                TypeOfRepair = ValidTypeOfRepair,
                PurchaseDate = ValidPurchaseDate,
                PurchasePrice = "ABC",
            };

            //Act
            ValidateCarAdminViewModel(model);

            // Assert
            Assert.Equal("ManufacturerIdValid", ValidateManufacturerId);
            Assert.Equal("VehicleModelIdValid", ValidateVehicleModelId);
            Assert.Equal("FinitionIdValid", ValidateFinitionId);
            Assert.Equal("YearValid", ValidateYear);
            Assert.Equal("KilometerValid", ValidateKilometer);
            Assert.Equal("RepairPriceValid", ValidateRepairPrice);
            Assert.Equal("TypeOfRepairValid", ValidateTypeOfRepair);
            Assert.Equal("PurchaseDateValid", ValidatePurchaseDate);
            Assert.Equal("PurchasePriceWrong", ValidatePurchasePrice);
        }
    }
}

using ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpressVoitures.Data
{
    public class ManufacturerSeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.Manufacturer.Any())
                return;

            // VOLKSWAGEN
            var volkswagen = new Manufacturer { Name = "Volkswagen" };
            context.Manufacturer.Add(volkswagen);
            await context.SaveChangesAsync();

            var golf = new VehicleModel { Name = "Golf", ManufacturerId = volkswagen.Id };
            var polo = new VehicleModel { Name = "Polo", ManufacturerId = volkswagen.Id };
            var passat = new VehicleModel { Name = "Passat", ManufacturerId = volkswagen.Id };
            context.VehicleModel.AddRange(golf, polo, passat);
            await context.SaveChangesAsync();

            context.Finition.AddRange(
                new Finition { Name = "Life", VehicleModelId = golf.Id },
                new Finition { Name = "GTE", VehicleModelId = golf.Id },
                new Finition { Name = "Carat", VehicleModelId = golf.Id },
                new Finition { Name = "Trendline", VehicleModelId = polo.Id },
                new Finition { Name = "Confortline", VehicleModelId = polo.Id },
                new Finition { Name = "Match", VehicleModelId = polo.Id },
                new Finition { Name = "Business", VehicleModelId = passat.Id },
                new Finition { Name = "Elegance", VehicleModelId = passat.Id },
                new Finition { Name = "Alltrack", VehicleModelId = passat.Id }
            );
            await context.SaveChangesAsync();

            // TOYOTA
            var toyota = new Manufacturer { Name = "Toyota" };
            context.Manufacturer.Add(toyota);
            await context.SaveChangesAsync();

            var corolla = new VehicleModel { Name = "Corolla", ManufacturerId = toyota.Id };
            var yaris = new VehicleModel { Name = "Yaris", ManufacturerId = toyota.Id };
            var rav = new VehicleModel { Name = "RAV4", ManufacturerId = toyota.Id };
            context.VehicleModel.AddRange(corolla, yaris, rav);
            await context.SaveChangesAsync();

            context.Finition.AddRange(
                new Finition { Name = "GR SPORT", VehicleModelId = corolla.Id },
                new Finition { Name = "Collection", VehicleModelId = corolla.Id },
                new Finition { Name = "Dynamic Business", VehicleModelId = yaris.Id },
                new Finition { Name = "Design", VehicleModelId = yaris.Id },
                new Finition { Name = "Iconic", VehicleModelId = yaris.Id },
                new Finition { Name = "Dynamic", VehicleModelId = rav.Id },
                new Finition { Name = "Trail", VehicleModelId = rav.Id },
                new Finition { Name = "Trek", VehicleModelId = rav.Id }
            );
            await context.SaveChangesAsync();

            // FORD
            var ford = new Manufacturer { Name = "Ford" };
            context.Manufacturer.Add(ford);
            await context.SaveChangesAsync();

            var mustang = new VehicleModel { Name = "Mustang", ManufacturerId = ford.Id };
            var focus = new VehicleModel { Name = "Focus", ManufacturerId = ford.Id };
            var fiesta = new VehicleModel { Name = "Fiesta", ManufacturerId = ford.Id };
            context.VehicleModel.AddRange(mustang, focus, fiesta);
            await context.SaveChangesAsync();

            context.Finition.AddRange(
                new Finition { Name = "GT", VehicleModelId = mustang.Id },
                new Finition { Name = "MACH-E", VehicleModelId = mustang.Id },
                new Finition { Name = "Dark Horse", VehicleModelId = mustang.Id },
                new Finition { Name = "Titanium", VehicleModelId = focus.Id },
                new Finition { Name = "ST-Line", VehicleModelId = focus.Id },
                new Finition { Name = "Active", VehicleModelId = fiesta.Id },
                new Finition { Name = "Vignale", VehicleModelId = fiesta.Id },
                new Finition { Name = "ST", VehicleModelId = fiesta.Id }
            );
            await context.SaveChangesAsync();

            // RENAULT
            var renault = new Manufacturer { Name = "Renault" };
            context.Manufacturer.Add(renault);
            await context.SaveChangesAsync();

            var clio = new VehicleModel { Name = "Clio", ManufacturerId = renault.Id };
            var megane = new VehicleModel { Name = "Megane", ManufacturerId = renault.Id };
            var scenic = new VehicleModel { Name = "Scénic", ManufacturerId = renault.Id };
            context.VehicleModel.AddRange(clio, megane, scenic);
            await context.SaveChangesAsync();

            context.Finition.AddRange(
                new Finition { Name = "Intens", VehicleModelId = clio.Id },
                new Finition { Name = "Esprit Alpine", VehicleModelId = clio.Id },
                new Finition { Name = "Initiale Paris", VehicleModelId = clio.Id },
                new Finition { Name = "GT-Line", VehicleModelId = megane.Id },
                new Finition { Name = "Iconic", VehicleModelId = megane.Id },
                new Finition { Name = "Equilibre", VehicleModelId = scenic.Id },
                new Finition { Name = "Bose Edition", VehicleModelId = scenic.Id },
                new Finition { Name = "Techno", VehicleModelId = scenic.Id }
            );
            await context.SaveChangesAsync();

            // PEUGEOT
            var peugeot = new Manufacturer { Name = "Peugeot" };
            context.Manufacturer.Add(peugeot);
            await context.SaveChangesAsync();

            var troisCentHuit = new VehicleModel { Name = "308", ManufacturerId = peugeot.Id };
            var quatreCentHuit = new VehicleModel { Name = "408", ManufacturerId = peugeot.Id };
            context.VehicleModel.AddRange(troisCentHuit, quatreCentHuit);
            await context.SaveChangesAsync();

            context.Finition.AddRange(
                new Finition { Name = "Tech Edition", VehicleModelId = troisCentHuit.Id },
                new Finition { Name = "Active Pack", VehicleModelId = quatreCentHuit.Id },
                new Finition { Name = "Allure", VehicleModelId = quatreCentHuit.Id },
                new Finition { Name = "GT Black Pack", VehicleModelId = quatreCentHuit.Id }

            );
            await context.SaveChangesAsync();

        }

    }
}

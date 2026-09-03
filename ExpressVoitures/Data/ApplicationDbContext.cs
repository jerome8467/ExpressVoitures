using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<CarImage> CarImage { get; set; }
        public DbSet<CarRepair> CarRepair { get; set; }
        public DbSet<CarTransaction> CarTransaction { get; set; }
        public DbSet<Finition> Finition { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Manufacturer)
                .WithMany()
                .HasForeignKey(c => c.ManufacturerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.VehicleModel)
                .WithMany()
                .HasForeignKey(c => c.VehicleModelId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Finition)
                .WithMany()
                .HasForeignKey(c => c.FinitionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VehicleModel>()
                .HasOne<Manufacturer>()
                .WithMany(m => m.VehicleModel)
                .HasForeignKey(v => v.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Finition>()
                .HasOne<VehicleModel>()
                .WithMany(v => v.Finition)
                .HasForeignKey(f => f.VehicleModelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarRepair>()
                .HasIndex(r => r.CarId)
                .IsUnique();

            modelBuilder.Entity<CarRepair>()
                .HasOne<Car>()
                .WithOne(c => c.CarRepair)
                .HasForeignKey<CarRepair>(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarTransaction>()
                .HasIndex(t => t.CarId)
                .IsUnique();

            modelBuilder.Entity<CarTransaction>()
                .HasOne<Car>()
                .WithOne(c => c.CarTransaction)
                .HasForeignKey<CarTransaction>(t => t.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarImage>()
                .HasOne<Car>()
                .WithMany(c => c.CarImage)
                .HasForeignKey(i => i.CarId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }



}

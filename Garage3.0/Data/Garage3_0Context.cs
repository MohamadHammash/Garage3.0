using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Models.Entities;

namespace Garage3._0.Data
{
    public class Garage3_0Context : DbContext
    {
        public Garage3_0Context (DbContextOptions<Garage3_0Context> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 1,
                VehicleType = VehicleType,
                RegNr = "ABC001",
                Color = "Red",
                Brand = "Volvo",
                Model = "XC40",
                NumberOfWheels = 4,
                ArrivalTime = new DateTime(2021, 3, 11, 8, 15, 30)
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 2,
                VehicleType = VehicleType.Car,
                RegNr = "BCA321",
                Color = "Black",
                Brand = "Toyota",
                Model = "Corolla",
                NumberOfWheels = 4,
                ArrivalTime = new DateTime(2021, 3, 11, 16, 25, 0)
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 3,
                VehicleType = VehicleType.Motorcycle,
                RegNr = "HDA555",
                Color = "Green",
                Brand = "Harley Davidson",
                Model = "Low rider",
                NumberOfWheels = 2,
                ArrivalTime = new DateTime(2021, 3, 11, 21, 10, 0)
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 4,
                VehicleType = VehicleType.Car,
                RegNr = "MLB11U",
                Color = "Blue",
                Brand = "Volkswagen",
                Model = "Golf",
                NumberOfWheels = 4,
                ArrivalTime = (DateTime.Now).AddHours(-1)
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 5,
                VehicleType = VehicleType.Truck,
                RegNr = "SCA777",
                Color = "White",
                Brand = "Scania",
                Model = "L320",
                NumberOfWheels = 4,
                ArrivalTime = (DateTime.Now).AddHours(-0.5)
            }); ;



        }

    }
}

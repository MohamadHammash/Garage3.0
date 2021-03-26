using Bogus;
using Bogus.Extensions.Sweden;
using Garage3._0.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Data
{
    public class SeedData
    {
        private static Faker fake;
        public static async Task InitAsync(IServiceProvider services)
        {
            using (var db = services.GetRequiredService<Garage3_0Context>())
            {
                fake = new Faker("sv");
                if (db.Members.Any())
                {
                    return;
                }
                var vehicles = GetVehicles();
                var members = GetMembers();

                await db.AddRangeAsync(members);

                foreach (var vehicle in vehicles)
                {
                    var r = fake.Random.Int(1, 75);
                    vehicle.Member = members[r];
                }
                await db.AddRangeAsync(vehicles);
                await db.SaveChangesAsync();

            }
        }
        private static List<Member> GetMembers()
        {
            var members = new List<Member>();
            for (int i = 0; i < 76; i++)
            {
                var regDate = fake.Date.Recent();
                var endDate = regDate.AddMonths(1);
                var member = new Member
                {
                    FirstName = fake.Name.FirstName(),
                    LastName = fake.Name.LastName(),
                    Personnummer = fake.Person.Personnummer(),
                    MbShipRegDate = regDate,
                    ProEndDate = endDate
                };
                members.Add(member);
            }

            return members;
        }
        private static List<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>();
            for (int i = 0; i < 60; i++)
            {
                var vehicle = new Vehicle
                {
                    Model = fake.Vehicle.Model(),
                    Brand = fake.Vehicle.Manufacturer(),
                    Color = fake.Lorem.Word(),
                    RegNr = fake.Vehicle.Vin(),
                    NumberOfWheels = fake.Random.Int(1, 10),
                    ArrivalTime = fake.Date.Recent(),
                    VehicleType = new VehicleType
                    {
                        TypeName = fake.Vehicle.Type()
                    },
                };
                vehicles.Add(vehicle);
            }
            return vehicles;
        }
    }
}
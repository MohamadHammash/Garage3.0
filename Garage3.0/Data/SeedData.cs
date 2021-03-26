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
                List<Member> members = new List<Member>();
                var vehicles = GetVehicles();

                for (int i = 0; i < vehicles.Count(); i++)
                {
                    var member = new Member
                    {
                        FirstName = fake.Name.FirstName(),
                        LastName = fake.Name.LastName(),
                        Personnummer = fake.Person.Personnummer(),
                        MbShipRegDate = fake.Date.Recent(),
                        ProEndDate = fake.Date.Soon()

                    };
                    members.Add(member);
                }
                await db.AddRangeAsync(members);


                foreach (var vehicle in vehicles)
                {

                    foreach (var member in members)
                    {
                        vehicle.Member = member;
                    }

                }
                await db.AddRangeAsync(vehicles);
                await db.SaveChangesAsync();

            }

        }







        private static List<Member> GetMembers()
        {
            var members = new List<Member>();

            for (int i = 0; i < 200; i++)
            {
                var fName = fake.Name.FirstName();
                var lName = fake.Name.LastName();

                var member = new Member
                {
                    FirstName = fName,
                    LastName = lName,
                    Personnummer = fake.Person.Personnummer(),
                    MbShipRegDate = fake.Date.Recent(),
                    ProEndDate = fake.Date.Soon()

                };

                members.Add(member);
            }

            return members;
        }
        private static List<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>();
            for (int i = 0; i < 100; i++)
            {
                var vehicle = new Vehicle
                {
                    Model = fake.Vehicle.Model(),
                    Brand = fake.Vehicle.Manufacturer(),
                    Color = fake.Lorem.Word(),
                    RegNr = fake.Vehicle.Vin(),
                    NumberOfwheeels = fake.Random.Int(1, 10),
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
//for (int i = 0; i < 100; i++)
//{
//    var vehicle = new Vehicle
//    {




//        Model = fake.Vehicle.Model(),
//        Color = fake.Vehicle.Manufacturer(),
//        VehicleType = new VehicleType()
//        {
//            TypeName = fake.Vehicle.Type()

//        },
//        RegNr = fake.Vehicle.Vin(),
//        NumberOfwheeels = 4,
//        ArrivalTime = fake.Date.Recent(),
//        Brand = fake.Vehicle.Model()



//    };

//    vehicles.Add(vehicle);
//}
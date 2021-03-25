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
                List<Member> members = GetMembers();
                await db.AddRangeAsync(members);

                var vehicles = new List<Vehicle>();

                for (int i = 0; i < 100; i++)
                {
                    var vehicle = new Vehicle
                    {
                        Model = fake.Vehicle.Model(),
                        Color = fake.Vehicle.Manufacturer(),
                        VehicleType = new VehicleType(),
                        RegNr = fake.Vehicle.Vin(),
                        NumberOfwheeels = 4


                    };

                    vehicles.Add(vehicle);
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

                };

                members.Add(member);
            }

            return members;
        }
        

    }
}

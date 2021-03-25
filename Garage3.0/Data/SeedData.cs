//using Bogus;
//using Garage3._0.Models.Entities;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Garage3._0.Data
//{
//    public class SeedData
//    {
//        private static Faker fake;

//        public static async Task InitAsync(IServiceProvider services)
//        {
//            using (var db = services.GetRequiredService<Garage3_0Context>())
//            {
//                fake = new Faker("sv");
//                // db.Database.EnsureDeleted();
//                // db.Database.Migrate();

//                if (db.Members.Any())
//                {
//                    return;
//                }
//                List<Member> members = GetMembers();
//                await db.AddRangeAsync(members);

//                var vehicles = new List<Vehicle>();

//                for (int i = 0; i < 100; i++)
//                {
//                    var vehicle = new Vehicle
//                    {
//                        Model = fake.Vehicle.Model(),
//                        Color = fake.Vehicle.Manufacturer(),
//                        VehicleType = new VehicleType(),
//                        RegNr = fake.Vehicle.Vin(),
//                        NumberOfwheeels = 4


//                    };

//                    vehicles.Add(vehicle);
//                }

//                await db.AddRangeAsync(vehicles);


//                var enrollments = new List<Enrollment>();

//                foreach (var student in students)
//                {
//                    foreach (var course in courses)
//                    {
//                        if (fake.Random.Int(0, 5) == 0)
//                        {
//                            var enrollment = new Enrollment
//                            {
//                                Course = course,
//                                Student = student,
//                                Grade = fake.Random.Int(1, 5)
//                            };
//                            enrollments.Add(enrollment);
//                        }
//                    }
//                }

//                await db.AddRangeAsync(enrollments);
//                await db.SaveChangesAsync();
//            }

//        }

//        private static List<Vehicle> GetMembers()
//        {
//            var students = new List<Vehicle>();

//            for (int i = 0; i < 200; i++)
//            {
//                var fName = fake.Name.FirstName();
//                var lName = fake.Name.LastName();

//                var student = new Student
//                {
//                    FirstName = fName,
//                    LastName = lName,
//                    Email = fake.Internet.Email($"{fName} {lName}"),
//                    Avatar = fake.Internet.Avatar(),
//                    Adress = new Adress
//                    {
//                        City = fake.Address.City(),
//                        Street = fake.Address.StreetAddress(),
//                        ZipCode = fake.Address.ZipCode()
//                    }

//                };

//                students.Add(student);
//            }

//            return students;
//        }

//    }
//}

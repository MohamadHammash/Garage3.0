using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.Entities
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }


    }
}
// add anumber to the parking spot 
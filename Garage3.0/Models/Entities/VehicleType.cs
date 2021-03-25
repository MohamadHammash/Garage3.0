using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
       [Display(Name = "Type")]
        public string TypeName { get; set; }
        [Display(Name = "Spots needed")]
        public int NumberOfSpots { get; set; }
        public int VehicleId { get; set; }

        // nav prop 

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}

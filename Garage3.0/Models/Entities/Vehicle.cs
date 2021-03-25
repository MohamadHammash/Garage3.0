using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.Entities
{
    public class Vehicle

    {
        public int VehicleID { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string RegistrationNumber { get; set; }


        public int NumberOfwheeels { get; set; }

        public int VehicleTypeId { get; set; }

        public int MemberId { get; set; }

        public DateTime ArrivalTime
        {
            get; set;

        }




    }
}

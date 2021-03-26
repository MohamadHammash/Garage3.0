using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.Entities
{
    public class Vehicle

    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }
        [Required]
        [Display(Name = "License number")]
        [RegularExpression("[A-Za-z]{3}[0-9]{2}[A-Za-z0-9]{1}", ErrorMessage = "Not a valid Registration Number.")]
        public string RegNr { get; set; }
        [Display(Name = "Number of wheels")]

        public int NumberOfWheels { get; set; }

        [Display(Name = "Arrival Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMMM-dd HH:mm}")]
        public DateTime ArrivalTime {get; set;}

        public int VehicleTypeId { get; set; }

        public int MemberId { get; set; }

        // nav prop
        public ICollection<ParkingSpot> ParkingSpots { get; set; }
        public Member Member { get; set; }
        public VehicleType VehicleType { get; set; }
       





    }
}


//[Remote("RegNumExists", "ParkedVehicles", AdditionalFields = "Id")]
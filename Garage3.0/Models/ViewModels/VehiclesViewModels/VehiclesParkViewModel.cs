using Garage3._0.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.VehiclesViewModels
{
    public class VehiclesParkViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }
        public string Color { get; set; }
        
        [Required]
        [Display(Name = "License number")]
        [Remote("RegNumExists", "ParkedVehicles", AdditionalFields = ("Id"))]
        [RegularExpression("[A-Za-z]{3}[0-9]{2}[A-Za-z0-9]{1}", ErrorMessage = "Not a valid Registration Number.")]
        public string RegNr { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime  { get; set; }
    //public string MemberFirstName { get; set; }
    //public string MemberLastName { get; set; }
    //public string MemberPersonnummer { get; set; }
    public int MemberId { get; set; }
        public int VehicleTypeId { get; set; }
        //public VehicleType VehicleType { get; set; }

    }
}

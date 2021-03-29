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
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }

        [Required]
        [Display(Name = "License number")]
        [Remote("RegNumExists", "Vehicles", AdditionalFields = ("Id"))]
        [RegularExpression("[A-Za-z]{3}[0-9]{2}[A-Za-z0-9]{1}", ErrorMessage = "Not a valid Registration Number.")]
        public string RegNr { get; set; }
        [Display(Name = "Number of wheels")]
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime  { get; set; }
        [Display(Name = "Owner")]
        public int MemberId { get; set; }
        [Display(Name = "Type")]
        public int VehicleTypeId { get; set; }
    }
}

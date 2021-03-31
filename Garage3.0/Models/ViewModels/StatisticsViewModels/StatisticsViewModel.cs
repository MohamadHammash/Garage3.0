using Garage3._0.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Garage3._0.Models.ViewModels.StatisticsViewModels
{
    public class MemberLisViewmodel
    {

        [Display(Name = "Available Vehicles")]
        public int AvailableVehicles { get; set; }

        [Display(Name = "Available ParkingSpot")]
        public int AvailableParkingSpot { get; set; }



    }
}

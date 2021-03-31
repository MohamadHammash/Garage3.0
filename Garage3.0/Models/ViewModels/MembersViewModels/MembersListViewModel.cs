using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.MembersViewModels
{
    public class MembersListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        public string Personnummer { get; set; }
        [Display(Name = "Vehicles owned")]
        public int VehiclesOwned { get; set; }

        //statistics
        [Display(Name = "Available Vehicles")]
        public int AvailableVehicles { get; set; }

        [Display(Name = "Available ParkingSpot")]
        public int AvailableParkingSpot { get; set; }


    }
}

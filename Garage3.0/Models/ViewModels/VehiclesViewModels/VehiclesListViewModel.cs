using Garage3._0.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.VehiclesViewModels
{
    public class VehiclesListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "License Number")]
        public string RegNr { get; set; }
        [Display(Name = "Type")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Arrival Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMMM-dd HH:mm}")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Owner")]
        public string MemberFullName { get; set; }
        public string Membership => IsPro ? "Pro" : "Normal";
        public bool IsPro { get; set; }
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "12:00")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan ParkingTime => DateTime.Now - ArrivalTime;




    }
}

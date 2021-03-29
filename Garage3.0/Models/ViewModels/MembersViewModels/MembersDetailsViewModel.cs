using Garage3._0.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.MembersViewModels
{
    public class MembersDetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Personnummer { get; set; }
        [Display(Name = "Registration date")]
        public DateTime MbShipRegDate { get; set; }
        [Display(Name = "Pro valid until")]
        public DateTime ProEndDate { get; set; }
        [Display(Name = "Vehicles Owned")]
        public int VehiclesOwned { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}

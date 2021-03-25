using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        public string  Personnummer { get; set; }
        [Display(Name = "Registration Date")]
        public DateTime MbShipRegDate { get; set; }
        [Display(Name = "Pro valid until")]
        public DateTime ProEndDate { get; set; }
       

        // nav prop
        public ICollection<Vehicle> Vehicles { get; set; }



    }
}
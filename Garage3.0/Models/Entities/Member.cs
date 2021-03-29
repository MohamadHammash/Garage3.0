using Garage3._0.Validations;
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
        [NotEqual("FirstName")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("([1-2][0|9])[0-9]{2}([0][0-9]|[1][0-2])([0-2][0-9]|[3][0-1])[-][0-9]{4}", ErrorMessage = "Only : YYYYMMDD-xxxx form is valid")]
        public string  Personnummer { get; set; }
        [Display(Name = "Registration Date")]
        public DateTime MbShipRegDate { get; set; }
        [Display(Name = "Pro valid until")]
        public DateTime ProEndDate { get; set; }
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";


        // nav prop
        public ICollection<Vehicle> Vehicles { get; set; }



    }
}
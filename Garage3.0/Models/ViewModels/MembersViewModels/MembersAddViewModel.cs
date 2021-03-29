using Garage3._0.Models.Entities;
using Garage3._0.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.MembersViewModels
{
    public class MembersAddViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [NotEqual("FirstName", ErrorMessage =" Last name shoud not be the same as the first name")]
        public string LastName { get; set; }
        [Required]
        [Remote("PersNumExists", "Members", AdditionalFields = ("Id"))]
        [RegularExpression("([1-2][0|9])[0-9]{2}([0][0-9]|[1][0-2])([0-2][0-9]|[3][0-1])[-][0-9]{4}", ErrorMessage = "Only : YYYYMMDD-xxxx form is valid")]
        public string Personnummer { get; set; }
        [Display(Name = "Registration date")]
        public DateTime MbShipRegDate { get; set; }
        [Display(Name = "Pro valid until")]
        public DateTime ProEndDate { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }


    }
}

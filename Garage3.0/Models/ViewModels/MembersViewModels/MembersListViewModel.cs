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
        public int VehiclesOwned { get; set; }

    }
}

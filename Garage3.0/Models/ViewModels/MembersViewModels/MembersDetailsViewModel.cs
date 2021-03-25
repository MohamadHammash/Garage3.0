﻿using Garage3._0.Models.Entities;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Personnummer { get; set; }
        public DateTime MbShipRegDate { get; set; }
        public DateTime ProEndDate { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.VehiclesViewModels
{
    public class VehiclesAddViewModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNr { get; set; }
        public int NumberOfwheeels { get; set; }
        public DateTime ArrivalTime => DateTime.Now;
        public string MemberFullName { get; set; }

    }
}

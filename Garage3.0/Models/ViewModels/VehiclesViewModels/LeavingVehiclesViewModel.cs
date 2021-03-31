using Garage3._0.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.VehiclesViewModels
{
    public class LeavingVehiclesViewModel
    {
        private const double initialFee = 50.0;
        private const double pricePerHour = 6.0;
        private double savedAsPro;
        public Vehicle LeavingVehicle { get; set; }

        public DateTime LeavingTime { get; set; }

        [Display(Name = "Parking Time")]
        [DisplayFormat(DataFormatString = "{0:hh':'mm}")]
        public TimeSpan ParkingTime { get; }
        public int NoOfSpots { get; set; }
        [Display(Name = "Savings")]
        public string SavedAsPro 
        { 
            get
            {
                return String.Format("{0:C}", savedAsPro);
            }
        }

        [Display(Name = "Parking Cost")]
        public string ParkingCost
        {
            get
            {
                var cost = NoOfSpots switch
                {
                    0 => 0,
                    1 => CalculateCost(1.0, 1.0),
                    2 => CalculateCost(1.3, 1.4),
                    _ => CalculateCost(1.6, 1.5),
                };
                cost = Math.Round(cost * 100) / 100;
                //string formattedForCurrency = 
                return String.Format("{0:C}", cost);
            }
        }

        private double CalculateCost(double incInitialFactor, double incHourFactor)
        {
            double originalCost = initialFee*incInitialFactor + pricePerHour*incHourFactor*ParkingTime.TotalHours;
            double totalCost;
            if (LeavingVehicle.Member.ProEndDate > DateTime.Now)
            {
                // Pro member
                double discountInitialFee = 1.0 - Math.Min(0.1 * NoOfSpots, 0.4);
                double discountRunningFee = 1.0;
                if (NoOfSpots >= 2) discountRunningFee = 0.90;
                totalCost = initialFee * incInitialFactor * discountInitialFee +
                            pricePerHour * incHourFactor * ParkingTime.TotalHours * discountRunningFee;
                savedAsPro = Math.Round((originalCost - totalCost) * 100) / 100;
                return totalCost;
            }
            return originalCost;
        }

        public LeavingVehiclesViewModel(Vehicle leavingVehicle)
        {
            LeavingVehicle = leavingVehicle;
            ParkingTime = DateTime.Now - LeavingVehicle.ArrivalTime;
            NoOfSpots = leavingVehicle.VehicleType.NumberOfSpots;
            NoOfSpots = NoOfSpots > 0 ? NoOfSpots : 0;
        }
    }
}

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
        public Vehicle LeavingVehicle { get; set; }

        public DateTime LeavingTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh':'mm}")]
        public TimeSpan ParkingTime { get; }
        public int NoOfSpots { get; set; }
        public double SavedAsPro { get; set; }

        public string ParkingCost
        {
            get
            {
                double cost;
                double tempCost = 0.0;
                switch (NoOfSpots)
                {
                    case 1:
                        tempCost = calculateCost(1.0, 1.0);
                        break;
                    case 2:
                        tempCost = calculateCost(1.3, 1.4);
                        break;
                    default:
                        tempCost = calculateCost(1.6, 1.5);
                        break;
                }
                cost = Math.Round(tempCost * 100) / 100;

                string formattedForCurrency = String.Format("{0:C}", cost);
                return formattedForCurrency;
            }
        }

        private double calculateCost(double incInitialFactor, double incHourFactor)
        {
            double originalCost = initialFee*incInitialFactor + pricePerHour*incHourFactor*ParkingTime.TotalHours;
            double totalCost = originalCost;
            if (LeavingVehicle.Member.ProEndDate > DateTime.Now)
            {
                // Pro member
                double discountInitialFee = 1.0 - Math.Min(0.1 * NoOfSpots, 0.4);
                double discountRunningFee = 1.0;
                if (NoOfSpots >= 2) discountRunningFee = 0.90;
                totalCost = initialFee * incInitialFactor * discountInitialFee +
                            pricePerHour * incHourFactor * ParkingTime.TotalHours * discountRunningFee;
                SavedAsPro = Math.Round((originalCost - totalCost) * 100) / 100;
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
            SavedAsPro = 0.0;
        }
    }
}

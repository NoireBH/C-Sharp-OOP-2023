using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + fuelConsumptionIncrease, tankCapacity)
        {

        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption - fuelConsumptionIncrease);

            if (FuelQuantity - fuelNeeded  < 0)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }

            else
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }

        }

    }
}

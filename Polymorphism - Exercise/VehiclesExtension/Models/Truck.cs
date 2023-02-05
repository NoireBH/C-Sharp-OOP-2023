using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;
        private const double refuelDecrease = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + fuelConsumptionIncrease, tankCapacity)
        {

        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else if (FuelQuantity + liters * refuelDecrease > TankCapacity)
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else
                base.Refuel(liters * refuelDecrease);
        }
    }
}

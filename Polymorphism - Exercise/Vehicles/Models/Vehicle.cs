using System;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {     
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            if (FuelQuantity < distance * FuelConsumption)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }

            else
            {   
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
        public override string ToString()
        => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

using System;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {     
        private double fuelQuantity;
        private double fuelConsumption;
        private double fuelCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {   
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        {
            get { return fuelQuantity; }

            set 
            {
                if (value >= TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }
        
            
        

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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                
            }

            else if (liters + fuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }

            else
            {
                FuelQuantity += liters;
            }

            
        }
        public override string ToString()
        => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

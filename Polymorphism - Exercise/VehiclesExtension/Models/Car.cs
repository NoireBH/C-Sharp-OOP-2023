using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionIncrease = 0.9;
        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption + fuelConsumptionIncrease,tankCapacity) 
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionIncrease = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + fuelConsumptionIncrease) 
        {

        }
    }
}

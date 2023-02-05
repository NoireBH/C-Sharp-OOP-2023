using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get;}
        public double FuelConsumption { get;}

        void Drive(double distance);
        void Refuel(double fuel);
    }
}

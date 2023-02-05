using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity { get;}
        public double FuelConsumption { get;}
        public double TankCapacity { get; }

        void Drive(double distance);
        void Refuel(double fuel);
    }
}

using System;
using Vehicles.Models;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);

            Car car = new Car(fuelQuantity, fuelConsumption);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdInfo = Console.ReadLine().Split();
                string command = cmdInfo[0];
                string vehicleType = cmdInfo[1];
                double value = double.Parse(cmdInfo[2]);

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        car.Drive(value);
                    }

                    else if (vehicleType == "Truck")
                    {
                        truck.Drive(value);
                    }
                }

                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(value);
                    }

                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);


        }
    }
}

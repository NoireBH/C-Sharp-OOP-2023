using System;
using VehiclesExtension.Models;

namespace VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);
            double tankCapacity = double.Parse(carInfo[3]);

            Car car = new Car(fuelQuantity, fuelConsumption,tankCapacity);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdInfo = Console.ReadLine().Split();
                ExecuteLogic(car, truck, bus, cmdInfo);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ExecuteLogic(Car car, Truck truck, Bus bus, string[] cmdInfo)
        {
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

                else if (vehicleType == "Bus")
                {
                    bus.Drive(value);
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

                else if (vehicleType == "Bus")
                {
                    bus.Refuel(value);
                }
            }

            else if (command == "DriveEmpty")
            {
                bus.DriveEmpty(value);
            }
        }
    }
}

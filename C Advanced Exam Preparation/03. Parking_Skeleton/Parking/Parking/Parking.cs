using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type,int capacity)
        {   
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Car> Data => data;
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer,string model)
        {
            var carToRemove = data.FirstOrDefault(p => p.Manifacturer == manufacturer && p.Model == model);

            if (carToRemove != default)
            {
                data.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (data.Count == 0)
            {
                return null;
            }

            return data[0];
        }

        public Car GetCar(string manufacturer,string model)
        {
            var carToGet = data.FirstOrDefault(p => p.Manifacturer == manufacturer && p.Model == model);

            if (carToGet != default)
            {
                return carToGet;
            }

            return default;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model,int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }
        public string Model { get; private set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<CPU> Multiprocessor => multiprocessor;
        public int Count => multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Count < Capacity)
            {
                multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            var multiprocessorToRemove = multiprocessor.FirstOrDefault(p => p.Brand == brand);

            if (multiprocessorToRemove != default)
            {
                multiprocessor.Remove(multiprocessorToRemove);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()       
         =>  multiprocessor.OrderByDescending(p => p.Frequency)
            .FirstOrDefault();
        
         

        public CPU GetCPU(string brand)
        {
            var multiprocessorToReturn = multiprocessor.FirstOrDefault(p => p.Brand == brand);

            if (multiprocessorToReturn != default)
            {
                return multiprocessorToReturn;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        
    }
}

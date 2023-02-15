using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private HashSet<Renovator> renovators;

        public Catalog(string name,int neededRenovators,string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new HashSet<Renovator>();
        }
        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }
        
        public IReadOnlyCollection<Renovator> Renovators => renovators;
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            else if (Count < NeededRenovators)
            {
                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }

            return "Renovators are no more needed.";
        }

      public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(r => r.Name == name);

            if (renovator == default)
            {
                return false;
            }

            renovators.Remove(renovator);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> renovatorsToRemove = renovators.Where(r => r.Type == type).ToList();
            int removedCount = renovatorsToRemove.Count;
           
            foreach (var renovator in renovatorsToRemove)
            {
                renovators.Remove(renovator);
            }

            return removedCount;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(r => r.Name == name);

            if (renovator == default)
            {
                return null;
            }

            renovator.Hired = true;
            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsToPay = new List<Renovator>();

            foreach (var renovator in renovators.Where(r => r.Days >= days))
            {
                renovatorsToPay.Add(renovator);
            }

            return renovatorsToPay;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
               
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private string name;
        private int capacity;
        private List<Child> registry;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            registry = new List<Child>();
        }
        
        public string Name { get;  set; }
        public int Capacity { get;  set; }

        public List<Child> Registry => registry;

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            var childToRemove = registry.FirstOrDefault(c => c.FirstName + " " + c.LastName == childFullName);

            if (childToRemove == default)
            {
                return false;
            }

            registry.Remove(childToRemove);
            return true;
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            var childToGet = Registry.FirstOrDefault(c => c.FirstName + " " + c.LastName == childFullName);

            if (childToGet == default)
            {
                return null;
            }

            return childToGet;
        }

        public string RegistryReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry.OrderByDescending(c => c.Age)
                .ThenBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().Trim();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var textiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var medicaments = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var healingItems = new Dictionary<string, int>()
            {
                {"Patch", 30 },
                {"Bandage", 40 },
                {"MedKit", 100 }
            };

            var createdItems = new Dictionary<string, int>();

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int currenSumValue = textiles.Peek() + medicaments.Peek();

                if (healingItems.Any(h => h.Value == currenSumValue))
                {
                    var currentItem = healingItems.First(h => h.Value == currenSumValue);
                    textiles.Dequeue();
                    medicaments.Pop();

                    if (!createdItems.ContainsKey(currentItem.Key))
                    {
                        createdItems[currentItem.Key] = 1;
                    }

                    else
                    {
                        createdItems[currentItem.Key]++;
                    }
                }

                else if (currenSumValue > healingItems["MedKit"])
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    int remainingValue = currenSumValue - healingItems["MedKit"];

                    int valueToAdd = medicaments.Pop() + remainingValue;
                    medicaments.Push(valueToAdd);

                    if (!createdItems.ContainsKey("MedKit"))
                    {
                        createdItems["MedKit"] = 1;
                    }

                    else
                    {
                        createdItems["MedKit"]++;
                    }
                }

                else
                {
                    textiles.Dequeue();
                    int valueToAdd = medicaments.Pop() + 10;
                    medicaments.Push(valueToAdd);
                }
            }

            if (textiles.Count == 0 && medicaments.Count > 0)
            {
                Console.WriteLine("Textiles are empty.");
            }

            else if (medicaments.Count == 0 && textiles.Count > 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            else if (medicaments.Count == 0 && textiles.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            foreach (var (name,amount) in createdItems.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{name} - {amount}");
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {String.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {String.Join(", ", textiles)}");
            }
                
            
        }
    }
}

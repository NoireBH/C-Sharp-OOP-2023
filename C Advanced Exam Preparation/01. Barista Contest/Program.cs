using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffeeQuantities = new Queue<int>(Console.ReadLine().Split(", "
                ,StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            var milkQuantities = new Stack<int>(Console.ReadLine().Split(", "
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            var menuOfDrinks = new Dictionary<string, int>
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },

            };

            var drinksMade = new Dictionary<string, int>();

            while (coffeeQuantities.Count > 0 && milkQuantities.Count > 0)
            {
                               
                var valueOfCoffeeAndMilk = coffeeQuantities.Peek() + milkQuantities.Peek();

                if (menuOfDrinks.Any(d => d.Value == valueOfCoffeeAndMilk))
                {
                    var drinkToGet = menuOfDrinks.FirstOrDefault(d => d.Value == valueOfCoffeeAndMilk);

                    if (!drinksMade.ContainsKey(drinkToGet.Key))
                    {
                        drinksMade.Add(drinkToGet.Key, 1);
                    }

                    else
                    {
                        drinksMade[drinkToGet.Key]++;
                    }

                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();

                }

                else
                {
                    coffeeQuantities.Dequeue();
                    var decreasedMilkQuantity = milkQuantities.Pop() - 5;
                    milkQuantities.Push(decreasedMilkQuantity);
                }
            }

            if (coffeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }

            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQuantities.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }

            else
            {
                Console.WriteLine($"Coffee left: {String.Join(", ", coffeeQuantities)}");
            }

            if (milkQuantities.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }

            else
            {
                Console.WriteLine($"Milk left: {String.Join(", ", milkQuantities)}");
            }

            foreach (var drink in drinksMade.OrderBy(d => d.Value)
                .ThenByDescending(d =>d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }


        }
    }
}

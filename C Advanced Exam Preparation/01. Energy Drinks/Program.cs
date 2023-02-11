using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalCaffeine = 0;
            const int maxCaffeine = 300;

            var milligramsOfCaffeine = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());
            var energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());

            while (energyDrinks.Count > 0 && milligramsOfCaffeine.Count > 0)
            {
                int currentCaffeine = milligramsOfCaffeine.Peek() * energyDrinks.Peek();

                if (currentCaffeine + totalCaffeine <= maxCaffeine)
                {
                    milligramsOfCaffeine.Pop();
                    energyDrinks.Dequeue();
                    totalCaffeine += currentCaffeine;
                }

                else
                {
                    milligramsOfCaffeine.Pop();
                    int moveToLast = energyDrinks.Dequeue();
                    energyDrinks.Enqueue(moveToLast);
                    totalCaffeine -= 30;

                    if (totalCaffeine < 0)
                    {
                        totalCaffeine = 0;
                    }
                }
                    
                
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: { string.Join(", ", energyDrinks)}");
            }

            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }
    }
}

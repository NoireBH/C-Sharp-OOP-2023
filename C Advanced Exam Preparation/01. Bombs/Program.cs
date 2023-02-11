using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bombPouch = new Dictionary<string, int>();

            var bombEffect = new Queue<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());

            var bombCasing = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());

            var bombs = new Dictionary<string, int>()
            {
                { "Datura Bombs", 40},
                { "Cherry Bombs", 60},
                { "Smoke Decoy Bombs", 120},
            };


            while (bombEffect.Count > 0 && bombCasing.Count > 0)
            {
                if (bombPouch.All(b => b.Value >= 3 ) && bombPouch.Count == 3)
                {
                    break;
                }

                var currentValue = bombEffect.Peek() + bombCasing.Peek();

                if (bombs.Any(b => b.Value == currentValue))
                {
                    var bombToAdd = bombs.First(b => b.Value == currentValue);
                    bombEffect.Dequeue();
                    bombCasing.Pop();

                    if (!bombPouch.ContainsKey(bombToAdd.Key))
                    {
                        bombPouch.Add(bombToAdd.Key, 1);
                    }

                    else
                    {
                        bombPouch[bombToAdd.Key] += 1;
                    }
                }

                else
                {
                    var casingToDecrease = bombCasing.Peek();
                    bombCasing.Pop();
                    bombCasing.Push(casingToDecrease - 5);
                }
            }

            if (bombPouch.All(b => b.Value >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count > 0)
            {   

                Console.WriteLine($"Bomb Effects: { String.Join(", ", bombEffect)}");
            }

            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", bombCasing)}");
            }

            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            if (bombPouch.ContainsKey("Cherry Bombs"))
            {
                Console.WriteLine($"Cherry Bombs: {bombPouch["Cherry Bombs"]}");
            }
                
            
            else
            {
                Console.WriteLine("Cherry Bombs: 0");
            }

            if (!bombPouch.ContainsKey("Datura Bombs"))
            {
                Console.WriteLine("Datura Bombs: 0");
            }

            else
            {
                Console.WriteLine($"Datura Bombs: {bombPouch["Datura Bombs"]}");
            }

            if (bombPouch.ContainsKey("Smoke Decoy Bombs"))
            {
                Console.WriteLine($"Smoke Decoy Bombs: {bombPouch["Smoke Decoy Bombs"]}");
            }

            else
            {
                Console.WriteLine("Smoke Decoy Bombs: 0");
            }
        }
    }
}

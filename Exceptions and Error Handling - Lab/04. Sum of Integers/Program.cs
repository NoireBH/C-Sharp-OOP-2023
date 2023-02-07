using System;
using System.Collections.Generic;

namespace _04._Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            int sum = 0;

            string[] inputInfo = Console.ReadLine().Split();

            foreach (var element in inputInfo)
            {
                int number = 0;

                try
                {
                     number = int.Parse(element);
                }
                catch (FormatException)
                {

                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch(OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }

                sum += number;
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}

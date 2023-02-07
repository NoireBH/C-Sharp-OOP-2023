using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
           var numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    if (!numbers.Any())
                    {
                        numbers.Add(ReadNumber(1, 100));
                    }

                    else
                    {
                        int currentMax = numbers.Max();
                        numbers.Add(ReadNumber(currentMax, 100));
                    }
                    
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                    
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(String.Join(", " ,numbers));

        }

        private static int ReadNumber(int start, int end)
        {           
                int n;
                try
                {
                     n = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid Number!");
                }
                

                if (n <= start || n >= end)
                {
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");
                }

                return n;
            
        }
    }
}


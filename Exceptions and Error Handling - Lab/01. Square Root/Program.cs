using System;

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double n = double.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new InvalidOperationException("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(n));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);

                
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
            

            
        }

       
    }
}

using System;

namespace _01.List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Algorithm(20);
        }

        static void Algorithm(int n)
        {
            if (n == 0)
            {
                return;
            }

            Algorithm(n - 1);
            Algorithm(n - 1);
        }
    }
}

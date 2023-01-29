using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(lenght, width, height);
                Console.WriteLine(box);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);              
            }
           
        }
    }
}

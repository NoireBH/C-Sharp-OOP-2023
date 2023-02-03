using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5,10);
            Circle circle = new Circle(10);
            Console.WriteLine(rectangle.CalculatePerimeter()); 
            Console.WriteLine(circle.CalculatePerimeter()); 
        }
    }
}

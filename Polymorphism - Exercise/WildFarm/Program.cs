

namespace WildFarm
{
    using System;
    using Core;
    using Core.Factory;
    using Core.Factory.Interfaces;
    using Core.Interfaces;
    using IO;
    using IO.Interfaces;
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            IEngine Engine = new Engine(reader, writer, animalFactory, foodFactory);
            Engine.Run();
        }
    }
}

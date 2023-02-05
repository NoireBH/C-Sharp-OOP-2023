

namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using Factory.Interfaces;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;
        private readonly ICollection<IAnimal> animals;
        public Engine(IReader reader, IWriter writer,
            IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.animals = new HashSet<IAnimal>();
        }

        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "End")
            {
                IAnimal animal = CreateAnimal(input);
                IFood food = CreateFood();

                this.writer.WriteLine(animal.AskForFood());
                animal.Feed(food);

                animals.Add(animal);
            }

            foreach (var currentAnimal in animals)
            {
                this.writer.WriteLine(currentAnimal);
            }
        }

        private IFood CreateFood()
        {
            string[] foodInfo = this.reader.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string foodType = foodInfo[0];
            int foodQuantity = int.Parse(foodInfo[1]);
            IFood currentFood = foodFactory.CreateFood(foodType, foodQuantity);

            return currentFood;
        }

        private IAnimal CreateAnimal(string input)
        {
            string[] inputInfo = input
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal currentAnimal = animalFactory.CreateAnimal(inputInfo);

            return currentAnimal;
        }
    }
}

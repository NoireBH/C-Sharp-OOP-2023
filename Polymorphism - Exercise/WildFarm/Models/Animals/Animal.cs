using System;


namespace WildFarm.Models.Animals
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Foods;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        protected abstract double WeigthMultipliyer { get;}
        public abstract IReadOnlyCollection<Type> PreferredFood { get; }

        public abstract string AskForFood();

        public void Feed(IFood food)
        {
            if (!PreferredFood.Any(f => f.Name == food.GetType().Name))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            else
            {
                Weight += food.Quantity * WeigthMultipliyer;
                FoodEaten += food.Quantity;
            }
        }
    }
}

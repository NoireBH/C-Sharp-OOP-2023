using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFood
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeigthMultipliyer 
            => DogWeightMultiplier;

        public override string AskForFood()
        {
            return $"Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

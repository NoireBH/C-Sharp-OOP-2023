using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;     

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFood
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeigthMultipliyer
            => MouseWeightMultiplier;

        public override string AskForFood()
        {
            return $"Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

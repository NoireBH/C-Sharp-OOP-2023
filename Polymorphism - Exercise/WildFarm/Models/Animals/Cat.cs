using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline, IFeline
    {
        private const double CatWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFood
            => new HashSet<Type> { typeof(Vegetable), typeof(Meat) };

        protected override double WeigthMultipliyer
            => CatWeightMultiplier;

        public override string AskForFood()
        {
            return $"Meow";
        }
    }
}

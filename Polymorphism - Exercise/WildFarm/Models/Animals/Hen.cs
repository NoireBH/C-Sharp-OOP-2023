using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFood
            => new HashSet<Type> 
            { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeigthMultipliyer
            => HenWeightMultiplier;

        public override string AskForFood()
        {
            return $"Cluck";
        }
    }
}

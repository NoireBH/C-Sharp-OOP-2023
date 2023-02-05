
namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFood 
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeigthMultipliyer 
            => OwlWeightMultiplier;

        public override string AskForFood()
        {
            return $"Hoot Hoot";
        }
    }
}

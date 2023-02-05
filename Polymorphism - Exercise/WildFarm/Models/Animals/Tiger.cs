using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFood
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeigthMultipliyer
            => TigerWeightMultiplier;

        public override string AskForFood()
        {
            return $"ROAR!!!";
        }
    }
}

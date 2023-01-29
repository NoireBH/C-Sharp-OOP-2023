using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double defaultGrams = 2.0;
        private const double WhiteModifier = 1.5;
        private const double WholeGrainModifier = 1.0;
        private const double CrispyModifier = 0.9;
        private const double CheweyModifier = 1.1;
        private const double HomemadeModifier = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;


        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {

                    flourType = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }


            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {

                    bakingTechnique = value;
                }

                else
                {
                    throw new Exception("Invalid type of dough.");
                }


            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }

                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double typeModifier = 0;
                double techniqueModifier = 0;
                string type = FlourType.ToString();
                string technique = BakingTechnique.ToString();

                switch (type.ToLower())
                {
                    case "white":
                        typeModifier = WhiteModifier;
                        break;
                    case "wholegrain":
                        typeModifier = WholeGrainModifier;
                        break;
                    default:
                        break;
                }

                switch (technique.ToLower())
                {
                    case "crispy":
                        techniqueModifier = CrispyModifier;
                        break;
                    case "chewy":
                        techniqueModifier = CheweyModifier;
                        break;
                    case "homemade":
                        techniqueModifier = HomemadeModifier;
                        break;
                    default:
                        break;
                }

                return defaultGrams * Weight * techniqueModifier * typeModifier;
            }
        }
    }
}


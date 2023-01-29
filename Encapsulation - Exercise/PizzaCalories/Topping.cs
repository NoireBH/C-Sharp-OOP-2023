using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double defaultGrams = 2.0;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;

        private string typeOfTopping;
        private double weight;

        public Topping(string type, double weight)
        {
            TypeOfTopping = type;
            Weight = weight;
        }
        public string TypeOfTopping
        {
            get => typeOfTopping;

            private set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies"
                    || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                    
                {
                    typeOfTopping = value;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }


            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{TypeOfTopping} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double typeModifier = 0;
                string topping = TypeOfTopping.ToString();
                switch (topping.ToLower())
                {
                    case "Meat":
                        typeModifier = MeatModifier;
                        break;
                    case "Veggies":
                        typeModifier = VeggiesModifier;
                        break;
                    case "Cheese":
                        typeModifier = CheeseModifier;
                        break;
                    case "Sauce":
                        typeModifier = SauceModifier;
                        break;
                    case "meat":
                        typeModifier = MeatModifier;
                        break;
                    case "veggies":
                        typeModifier = VeggiesModifier;
                        break;
                    case "cheese":
                        typeModifier = CheeseModifier;
                        break;
                    case "sauce":
                        typeModifier = SauceModifier;
                        break;
                    default:
                        break;
                }

                return defaultGrams * Weight * typeModifier;
            }
        }
    }
}


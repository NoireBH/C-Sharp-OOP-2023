using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }

                name = value;
            }
        }




        public string Size
        {
            get { return size; }
            private set
            {
                if (value == "Small" || value == "Middle" || value == "Large")
                {
                    size = value;
                }

            }
        }


        public double Price
        {
            get { return price; }
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }

                else if (Size == "Middle")
                {
                    price = (value / 3) * 2;
                }

                else if (Size == "Small")
                {
                    price = value / 3;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name 
        {
            get => name;

           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

           private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
            => products;

        public bool AddProduct(Product product)
        {
            if (Money - product.Cost < 0)
            {               
                return false;
            }

            Money -= product.Cost;
            products.Add(product);
            return true;
        }
    }
}

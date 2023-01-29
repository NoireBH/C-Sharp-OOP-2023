using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleToAdd = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsToAdd = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            

            try
            {
                foreach (var currentPerson in peopleToAdd)
                {
                    string[] personInfo = currentPerson.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person person = new Person(name, money);
                    people.Add(name, person);
                }

                foreach (var currentProduct in productsToAdd)
                {
                    string[] ProductInfo = currentProduct.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = ProductInfo[0];
                    decimal cost = decimal.Parse(ProductInfo[1]);

                    Product product = new Product(name, cost);
                    products.Add(name, product);
                }

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] personAndBoughtProduct = input.Split();
                    string personName = personAndBoughtProduct[0];
                    string productName = personAndBoughtProduct[1];
                    Person person = people[personName];
                    Product product = products[productName];
                    

                    bool isBought = person.AddProduct(product);

                    if (!isBought)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }

                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }

                foreach (var person in people)
                {
                    bool hasBoughtSomething = person.Value.Products.Count > 0;

                    if (!hasBoughtSomething)
                    {
                        Console.WriteLine($"{person.Value.Name} - Nothing bought");
                    }

                    else
                    {
                        Console.WriteLine($"{person.Value.Name}" +
                            $" - {string.Join(", ", person.Value.Products.Select(p => p.Name))}");
                    }
                }

            }
            
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                

                string[] pizzaInfo = Console.ReadLine().Split(' ');
                string name = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine().Split();
                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double weight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(name, dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppings = input.Split();
                    string type = toppings[1];
                    double weightOfTopping = double.Parse(toppings[2]);

                    Topping topping = new Topping(type, weightOfTopping);
                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }
    }
}

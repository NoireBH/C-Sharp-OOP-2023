using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            var buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split();

                if (peopleInfo.Length == 4)
                {
                    string name = peopleInfo[0];
                    int age = int.Parse(peopleInfo[1]);
                    string id = peopleInfo[2];
                    string birthdate = peopleInfo[3];
                    Citizen citizen = new Citizen(name,age, id, birthdate);
                    buyers.Add(citizen);
                }

                else if (peopleInfo.Length == 3)
                {
                    string name = peopleInfo[0];
                    int age = int.Parse(peopleInfo[1]);
                    string group = peopleInfo[2];
                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
                

            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string currentBuyer = input;

                if (buyers.Any(b => b.Name == currentBuyer))
                {
                    IBuyer buyer = buyers.Find(p => p.Name == currentBuyer);
                    buyer.BuyFood();
                }
                

            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var meals = new Queue<string>(Console.ReadLine()
                .Split(" ").ToArray());
            var caloriesPerDay = new Stack<int>(Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray());

            var mealsAndCalories = new Dictionary<string, int>
            {
                {"salad" , 350},
                {"soup", 490 },
                {"pasta",680 },
                {"steak", 790 }

            };


            int mealsEaten = 0;
            int leftover = 0;
            bool isNextDay = false;

            while (meals.Count > 0 && caloriesPerDay.Count > 0)
            {
                string meal = meals.Peek();
                int currCal = caloriesPerDay.Peek();
                int currMealCal = 0;


                if (!isNextDay)
                {
                    currMealCal = mealsAndCalories[meal];
                }

                else
                {
                    currMealCal = leftover;
                }

                if (currCal > currMealCal)
                {
                    meals.Dequeue();
                    caloriesPerDay.Pop();
                    currCal -= currMealCal;
                    caloriesPerDay.Push(currCal);
                    mealsEaten++;
                    isNextDay = false;
                }
                else
                {
                    caloriesPerDay.Pop();
                    currMealCal -= currCal;
                    leftover = currMealCal;
                    isNextDay = true;

                    if (caloriesPerDay.Count == 0)
                    {
                        meals.Dequeue();
                        mealsEaten++;
                    }

                }

                if (meals.Count <= 0)
                {
                    Console.WriteLine($"John had {mealsEaten} meals.");
                    Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
                }

                else
                {
                    Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                    Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
                }


            }
        }
    }
}
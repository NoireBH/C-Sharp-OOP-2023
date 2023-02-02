using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen :  IBuyer
    {
        public Citizen(string name, int age, string ID, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = ID;
            this.BirthDate = birthDate;
            this.Food = 0;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string BirthDate {get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
      
    }
}

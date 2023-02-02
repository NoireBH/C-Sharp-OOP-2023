using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IBirthdate
    {
        public Citizen(string name, int age, string ID, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = ID;
            this.BirthDate = birthDate;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string BirthDate {get; private set; }

        public void CheckID(string fakeID)
        {
            if (this.ID.EndsWith(fakeID))
            {
                Console.WriteLine(this.ID);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string ID)
        {
            this.Name = name;
            this.Age = age;
            this.ID = ID;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public void CheckID(string fakeID)
        {
            if (this.ID.EndsWith(fakeID))
            {
                Console.WriteLine(this.ID);
            }
        }
    }
}

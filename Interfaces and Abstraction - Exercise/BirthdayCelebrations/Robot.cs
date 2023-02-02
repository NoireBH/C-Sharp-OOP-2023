using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string iD)
        {
            Name = model;
            ID = iD;
        }

        public string Name {get; private set;}

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

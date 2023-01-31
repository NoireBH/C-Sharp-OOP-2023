using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var citizensAndRobots = new List<IIdentifiable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    Citizen citizen = new Citizen(name, age, id);
                    citizensAndRobots.Add(citizen);
                }

                else if (info.Length == 2)
                {
                    string model = info[0];
                    string id = info[1];

                    Robot robot = new Robot(model, id);
                    citizensAndRobots.Add((robot));
                }
                
            }

            string fakeIdDigits = Console.ReadLine();

            foreach (var person in citizensAndRobots)
            {
                person.CheckID(fakeIdDigits);
            }
        }
    }
}

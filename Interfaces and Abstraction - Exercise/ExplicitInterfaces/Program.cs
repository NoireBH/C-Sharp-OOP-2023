using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input.Split();
                string name = personInfo[0];
                string country = personInfo[1];
                int age = int.Parse(personInfo[2]);

                IPerson person = new Citizen(name,age,country);
                IResident resident = new Citizen(name,age,country);
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName()); 

            }
            
        }
    }
}
